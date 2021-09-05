
using BackEnd.Cliente.Dominio.Repositories;
using BackEnd.Cuenta.Dominio.Repositories;
using System;

namespace BackEnd.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteServiceRepository ClienteServiceRepository { get; }
        ICuentaServiceRepository CuentaServiceRepository { get; }
        int Commit();
    }
}
