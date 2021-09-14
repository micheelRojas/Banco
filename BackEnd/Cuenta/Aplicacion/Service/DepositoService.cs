using BackEnd.Base;
using BackEnd.Cuenta.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Service
{
   public class DepositoService
    {
        readonly IUnitOfWork _unitOfWork;
        public DepositoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TransaccionResponse Ejecutar(DepositoRequest request)
        {
            Dominio.Cuenta cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.NumeroCuenta == request.NumeroCuenta);
            if (cuenta == null)
            {
                return new TransaccionResponse($"Cuenta no existe");
            }
            else
            {
                cuenta.Saldo = request.Transaccion(cuenta.Saldo, request.Valor);
                _unitOfWork.CuentaServiceRepository.Edit(cuenta);
                _unitOfWork.Commit();
                return new TransaccionResponse($"Transaccion Exitosamente");

            }
        }
    }
}
