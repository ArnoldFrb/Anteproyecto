using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.Repositories
{
    class ConvocatoriaRepository : GenericRepository<Convocatoria>, IConvocatoriaRepository
    {
        public ConvocatoriaRepository(IDbContext context) : base(context)
        {
        }
    }
}
