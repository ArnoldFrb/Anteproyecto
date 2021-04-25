using System;
using System.Collections.Generic;
using System.Text;
using Anteproyecto.Domain.Repositories;

namespace Anteproyecto.Domain.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }

        IProyectoRepository ProyectoRepository { get; }

        IConvocatoriaRepository ConvocatoriaRepository { get; }

        int Commit();
    }
}
