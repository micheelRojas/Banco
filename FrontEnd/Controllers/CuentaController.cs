using BackEnd;
using BackEnd.Base;
using BackEnd.Cliente.Dominio;
using BackEnd.Cuenta.Aplicacion.Request;
using BackEnd.Cuenta.Aplicacion.Service;
using BackEnd.Cuenta.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly BancoContext _context;
        private CrearCuentaService _service;
        private DepositoService _depositoService;
        private RetiroService _retiroService;
        private UnitOfWork _unitOfWork;
        public CuentaController(BancoContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuenta([FromBody] int id)
        {
            string numCuenta = id.ToString();
            Cuenta cuenta = await _context.Cuenta.SingleOrDefaultAsync(t => t.NumeroCuenta == numCuenta);
            if (cuenta == null)
                return NotFound();
            return Ok(cuenta);
        }
        [HttpGet]
        public object GetCuentas()
        {
            var result = (from c in _context.Set<Cuenta>()
                          join cl in _context.Set<Cliente>()
                          on c.IdCliente equals cl.Id
                          select new
                          {
                              id = c.Id,
                              numeroCuenta = c.NumeroCuenta,
                              saldo= c.Saldo,
                              idCliente = c.IdCliente,
                              nombreCliente = cl.Nombre,

                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("GetCuentaBuscada/{id}")]
        public object GetCuentaBuscada([FromRoute] int id)
        {
            string numCuenta = id.ToString();
            var result = (from c in _context.Set<Cuenta>()
                          join cl in _context.Set<Cliente>()
                          on c.IdCliente equals cl.Id
                          where c.NumeroCuenta.Equals(numCuenta)
                          select new
                          {
                              id = c.Id,
                              numeroCuenta = c.NumeroCuenta,
                              saldo = c.Saldo,
                              cliente = cl.Nombre,

                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCuenta([FromBody] CrearCuentaRequest cuenta)
        {
            _service = new CrearCuentaService(_unitOfWork);
            var rta = _service.Ejecutar(cuenta);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { id = cuenta.id }, cuenta);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("PutDeposito/{numeroCuenta}")]
        public async Task<IActionResult> PutDeposito([FromRoute] string numeroCuenta, [FromBody] DepositoRequest cuenta)
        {
            _depositoService = new DepositoService (_unitOfWork);
          double n=  cuenta.Valor;
            var rta = _depositoService.Ejecutar(cuenta);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { numeroCuenta = cuenta.NumeroCuenta }, cuenta);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("PutRetiro/{numeroCuenta}")]
        public async Task<IActionResult> PutRetiro([FromBody] RetiroRequest cuenta)
        {
            _retiroService = new RetiroService(_unitOfWork);
            var rta = _retiroService.Ejecutar(cuenta);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCuenta", new { numeroCuenta = cuenta.NumeroCuenta }, cuenta);
            }
            return BadRequest(rta.Message);
        }
    }
}
