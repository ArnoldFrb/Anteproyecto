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
            return new Convocatoria(new DateTime(2021, 1, 1, 12, 0, 0), new DateTime(2021, 3, 1, 12, 0, 0));
        }
    }
}
