using Anteproyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.ObjectMother
{
    public static class CrearConvocatoriaMother
    {
        public static Convocatoria CrearConvocatoria()
        {
            return new Convocatoria(DateTime.Now, DateTime.Now);
        }
    }
}
