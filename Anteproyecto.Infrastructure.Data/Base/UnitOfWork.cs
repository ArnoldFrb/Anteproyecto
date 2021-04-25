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

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
