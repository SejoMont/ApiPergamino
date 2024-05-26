using ApiPergamino.Data.ApiPergamino.Data;
using ApiPergamino.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPergamino.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetPersonajesAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindPersonajeAsync(int id)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }

        private async Task<int> GetMaxIdPersonajeAsync()
        {
            return await this.context.Empleados.MaxAsync(x => x.IdEmpleado) + 1;
        }

        public async Task<Empleado> CreatePersonajeAsync(string nombre, string imagen, string oficio)
        {
            Empleado personaje = new Empleado
            {
                IdEmpleado = await this.GetMaxIdPersonajeAsync(),
                Apellido = nombre,
                Oficio = imagen
            };

            this.context.Empleados.Add(personaje);
            await this.context.SaveChangesAsync();
            return personaje;
        }

        public async Task UpdatePersonajeAsync(int id, string nombre, int salario)
        {
            Empleado empleado = await this.FindPersonajeAsync(id);
            empleado.Apellido = nombre;
            empleado.Salario = salario;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int id)
        {
            Empleado empleado = await this.FindPersonajeAsync(id);
            this.context.Empleados.Remove(empleado);
            await this.context.SaveChangesAsync();
        }
    }
}
