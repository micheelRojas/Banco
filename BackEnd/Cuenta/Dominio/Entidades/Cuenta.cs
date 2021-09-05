using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cuenta.Dominio
{
   public class Cuenta : Entity<int>
    { 
        public string NumeroCuenta { get; set; }
        public Double Saldo { get; set; }
        public int IdCliente { get; set; }
        public Cuenta(string numeroCuenta, double saldo, int idCliente)
        {
            NumeroCuenta = numeroCuenta;
            Saldo = saldo;
            IdCliente = idCliente;
        }

    }
}
