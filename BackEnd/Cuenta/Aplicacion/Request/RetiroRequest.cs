using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Request
{
    public class RetiroRequest : TransaccionRequest
    {
        public override Double Transaccion(Double saldo,Double valor)
        {
            if (saldo >= valor)
            {
                 saldo = saldo - valor;
            }
            return saldo;
        }
    }
}
