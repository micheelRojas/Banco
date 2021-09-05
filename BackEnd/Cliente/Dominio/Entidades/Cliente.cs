using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Cliente.Dominio
{
   public class Cliente : Entity<int>
    {
        public string Nombre { get; set; }
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }
    }
}
