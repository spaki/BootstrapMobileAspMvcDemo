using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Infra
{
    public class Repositorio : DbContext
    {
        public Repositorio() : base("DefaultConnection")
        {
        }

        public DbSet<Letra> Letras { get; set; }
    }
}