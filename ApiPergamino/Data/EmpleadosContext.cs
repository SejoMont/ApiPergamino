using ApiPergamino.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPergamino.Data
{
    namespace ApiPergamino.Data
    {
        public class EmpleadosContext : DbContext
        {
            public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }
            public DbSet<Empleado> Empleados { get; set; }
        }
    }
}
