using BackEnd.Base;
using BackEnd.Cliente.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cliente.Infra
{
  public  class ClienteServiceRepository : GenericRepository<Dominio.Cliente>, IClienteServiceRepository
    {
        public ClienteServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
