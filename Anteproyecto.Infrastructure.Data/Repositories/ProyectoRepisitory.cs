using Anteproyecto.Domain;
using Anteproyecto.Domain.Repositories;
using Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.Repositories
{
    class ProyectoRepisitory : GenericRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepisitory(IDbContext context) : base(context)
        {
        }
    }
}
