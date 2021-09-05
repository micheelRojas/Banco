using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cliente.Aplicacion.Request
{
    public class CrearClienteRequest
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public IReadOnlyList<string> CanCrear(CrearClienteRequest cliente)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(cliente.Nombre.ToString()))
                errors.Add("Campo Nombre del Grado vacio");
            return errors;

        }

        public class CrearClienteResponse
        {
            public CrearClienteResponse(string message)
            {
                Message = message;
            }

            public string Message { get; set; }
            public bool isOk()
            {
                return this.Message.Equals("Cliente Creado Exitosamente");
            }
        }
    }
}
