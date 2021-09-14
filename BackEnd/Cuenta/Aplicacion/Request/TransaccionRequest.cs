using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Request
{
   public abstract class TransaccionRequest
    {
        public string NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public double Valor { get; set; }
        public abstract Double Transaccion(Double saldo,Double valor);
    }
    public class TransaccionResponse
    {
        public TransaccionResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Transaccion Exitosamente");
        }
    }
}
