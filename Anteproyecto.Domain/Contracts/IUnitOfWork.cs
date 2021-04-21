using System;
using System.Collections.Generic;
using System.Text;
using Anteproyecto.Domain.Repositories;

namespace Anteproyecto.Domain.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }

        int Commit();
    }
}
