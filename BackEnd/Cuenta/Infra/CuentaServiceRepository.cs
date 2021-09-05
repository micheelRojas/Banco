using BackEnd.Base;
using BackEnd.Cuenta.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Infra
{
  public  class CuentaServiceRepository : GenericRepository<Dominio.Cuenta>, ICuentaServiceRepository
    {
        public CuentaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
