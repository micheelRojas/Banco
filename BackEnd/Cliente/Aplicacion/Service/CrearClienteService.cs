using BackEnd.Base;
using BackEnd.Cliente.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackEnd.Cliente.Aplicacion.Request.CrearClienteRequest;

namespace BackEnd.Cliente.Aplicacion.Service
{
    public class CrearClienteService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearClienteResponse Ejecutar(CrearClienteRequest request)
        {
            var cliente = _unitOfWork.ClienteServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.Nombre == request.Nombre);
            if (cliente != null)
            {
                return new CrearClienteResponse($"Cliente ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearClienteResponse(ListaErrors);
            }
            Dominio.Cliente newGrado = new Dominio.Cliente(request.Nombre.ToUpper());
            _unitOfWork.ClienteServiceRepository.Add(newGrado);
            _unitOfWork.Commit();
            return new CrearClienteResponse($"Cliente Creado Exitosamente");
        }
    }
}
