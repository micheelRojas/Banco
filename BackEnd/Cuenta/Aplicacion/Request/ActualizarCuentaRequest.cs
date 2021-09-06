using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Request
{
    public class ActualizarCuentaRequest
    {
        public int id { get; set; }
        public int Saldo { get; set; }

    }
    public class ActualizarCuentaResponse
    {
        public ActualizarCuentaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Cuenta Actualizada Exitosamente");
        }
    }
}
