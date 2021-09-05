using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Aplicacion.Request
{
    public class CrearCuentaRequest
    {
        public int id { get; set; }
        public string NumeroCuenta { get; set; }
        public Double Saldo { get; set; }
        public int IdCliente { get; set; }
        public IReadOnlyList<string> CanCrear(CrearCuentaRequest cuenta)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(cuenta.NumeroCuenta.ToString()))
                errors.Add("Campo Nombre del Grado vacio");
            if (cuenta.IdCliente == 0)
                errors.Add("Campo identiificacion  de Cliente  vacio");
            return errors;

        }

        public class CrearCuentaResponse
        {
            public CrearCuentaResponse(string message)
            {
                Message = message;
            }

            public string Message { get; set; }
            public bool isOk()
            {
                return this.Message.Equals("Cuenta Creado Exitosamente");
            }
        }
    }
}
