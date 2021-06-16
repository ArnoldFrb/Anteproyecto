using Anteproyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.ObjectMother
{
    public static class ProyectoMother
    {
        public static Proyecto crearProyecto(string nombre)
        {
            return new Proyecto(nombre, "este es un proyecto mas");
        }
    }
}
