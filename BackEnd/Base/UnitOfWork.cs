
using BackEnd.Cliente.Dominio.Repositories;
using BackEnd.Cliente.Infra;
using BackEnd.Cuenta.Dominio.Repositories;
using BackEnd.Cuenta.Infra;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        //Repositorios
        private IClienteServiceRepository _clienteServiceRepository;
        public IClienteServiceRepository ClienteServiceRepository
        {
            get
            {
                return _clienteServiceRepository ?? (_clienteServiceRepository = new ClienteServiceRepository(_dbContext));
            }
        }
        private ICuentaServiceRepository _cuentaServiceRepository;
        public ICuentaServiceRepository CuentaServiceRepository
        {
            get
            {
                return _cuentaServiceRepository ?? (_cuentaServiceRepository = new CuentaServiceRepository(_dbContext));
            }
        }



        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
