using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class BancoContext : DbContextBase
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=BdBanco; Integrated Security=True; MultipleActiveResultSets=True");
        }
        public BancoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente.Dominio.Cliente> Cliente { get; set; }
        public DbSet<Cuenta.Dominio.Cuenta> Cuenta { get; set; }
    }
}
