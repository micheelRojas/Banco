using BackEnd.Base;
using BackEnd.Cuenta.Aplicacion.Request;

namespace BackEnd.Cuenta.Aplicacion.Service
{
    public class RetiroService
    {
        readonly IUnitOfWork _unitOfWork;
        public RetiroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TransaccionResponse Ejecutar(RetiroRequest request)
        {
            Dominio.Cuenta cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.NumeroCuenta == request.NumeroCuenta);
            if (cuenta == null)
            {
                return new TransaccionResponse($"Cuenta no existe");
            }
            else
            {
                cuenta.Saldo = request.Transaccion(cuenta.Saldo,request.Valor);
                _unitOfWork.CuentaServiceRepository.Edit(cuenta);
                _unitOfWork.Commit();
                return new TransaccionResponse($"Transaccion Exitosamente");

            }
        }
    }
}
