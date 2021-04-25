using System;
using System.Collections.Generic;
using System.Text;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Repositories;
using Anteproyecto.Infrastructure.Data.Repositories;
using Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork 
    {
        private IDbContext _dbContext;

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        public IUsuarioRepository _UsuarioRepository;

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_UsuarioRepository == null)
                {
                   return _UsuarioRepository = new UsuarioRepository(_dbContext);
                }
                return _UsuarioRepository;
            }
        }

        public IProyectoRepository _ProyectoRepository;

        public IProyectoRepository ProyectoRepository
        {
            get
            {
                if (_ProyectoRepository == null)
                {
                    return _ProyectoRepository = new ProyectoRepisitory(_dbContext);
                }
                return _ProyectoRepository;
            }
        }

        public IConvocatoriaRepository _ConvocatoriaRepository;

        public IConvocatoriaRepository ConvocatoriaRepository
        {
            get
            {
                if (_ConvocatoriaRepository == null)
                {
                    return _ConvocatoriaRepository = new ConvocatoriaRepository(_dbContext);
                }
                return _ConvocatoriaRepository;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
    }

        public void Dispose()
        {
              Dispose(true);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

}
}
