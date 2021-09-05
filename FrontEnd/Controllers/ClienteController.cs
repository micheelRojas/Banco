using BackEnd;
using BackEnd.Base;
using BackEnd.Cliente.Aplicacion.Request;
using BackEnd.Cliente.Aplicacion.Service;
using BackEnd.Cliente.Dominio;
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
    public class ClienteController : ControllerBase
    {
        private readonly BancoContext _context;
        private CrearClienteService _service;
        private UnitOfWork _unitOfWork;
        public ClienteController(BancoContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente([FromRoute] int id)
        {
            Cliente cliente = await _context.Cliente.SingleOrDefaultAsync(t => t.Id == id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }
        [HttpGet]
        public object GetClientes()
        {
            var result = (from c in _context.Set<Cliente>()
                          select new
                          {
                              id = c.Id,
                              nombre = c.Nombre
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] CrearClienteRequest cliente)
        {
            _service = new CrearClienteService(_unitOfWork);
            var rta = _service.Ejecutar(cliente);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCliente", new { id = cliente.id }, cliente);
            }
            return BadRequest(rta.Message);
        }
    }
}
