using BackEnd.Base;
using BackEnd.Cuenta.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackEnd.Cuenta.Aplicacion.Request.CrearCuentaRequest;

namespace BackEnd.Cuenta.Aplicacion.Service
{
    public class CrearCuentaService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearCuentaResponse Ejecutar(CrearCuentaRequest request)
        {
            var cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.NumeroCuenta == request.NumeroCuenta || t.Saldo== request.Saldo || t.IdCliente == request.IdCliente );
            if (cuenta != null)
            {
                return new CrearCuentaResponse($"Cuenta ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearCuentaResponse(ListaErrors);
            }
            Dominio.Cuenta newCuenta = new Dominio.Cuenta(request.NumeroCuenta.ToUpper(), request.Saldo, request.IdCliente);
            _unitOfWork.CuentaServiceRepository.Add(newCuenta);
            _unitOfWork.Commit();
            return new CrearCuentaResponse($"Cliente Creado Exitosamente");
        }
    }
}
