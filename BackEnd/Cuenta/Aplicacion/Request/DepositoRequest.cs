using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Request
{
    public class DepositoRequest : TransaccionRequest
    {
        
        public override Double Transaccion(double saldo, double valor)
        {

            if (valor > 0)
            {
                saldo = saldo + valor;
            }
            return saldo;
        }
    }
}
