using Anteproyecto.Domain;
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
    public class ProyectoRepository : GenericRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(IDbContext context) : base(context)
        {
        }
    }
}
