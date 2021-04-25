using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.Test.Dobles
{
    class UnitOfWorkFake : IUnitOfWork
    {
        public IUsuarioRepository _UsuarioRepository;
         
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_UsuarioRepository == null)
                {
                    return _UsuarioRepository = new CuentaRepositoryFake();
                }
                return _UsuarioRepository;
            }
        }

        public IProyectoRepository ProyectoRepository => throw new NotImplementedException();

        public IConvocatoriaRepository ConvocatoriaRepository => throw new NotImplementedException();

        public int Commit()
        {
            Console.WriteLine("Se confirman cambios en la base de datos");
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
