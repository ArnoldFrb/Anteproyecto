using Anteproyecto.Domain;
using Anteproyecto.Domain.Repositories;
using Infrastructure.Data.Base;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IDbContext context) : base(context)
        {

        }
    }
}
