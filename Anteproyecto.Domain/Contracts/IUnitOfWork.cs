using System;
using System.Collections.Generic;
using System.Text;
using Anteproyecto.Domain.Repositories;

namespace Anteproyecto.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
