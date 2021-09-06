using BackEnd.Base;
using BackEnd.Cuenta.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Service
{
   public class ActualizarCuentaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActualizarCuentaResponse Ejecutar(ActualizarCuentaRequest request)
        {
            Dominio.Cuenta cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (cuenta == null)
            {
                return new ActualizarCuentaResponse($"Cuenta no existe");
            }
            else
            {
                cuenta.Saldo = request.Saldo;
                _unitOfWork.CuentaServiceRepository.Edit(cuenta);
                return new ActualizarCuentaResponse($"Cuenta Actualizada Exitosamente");

            }
        }
    }
}
