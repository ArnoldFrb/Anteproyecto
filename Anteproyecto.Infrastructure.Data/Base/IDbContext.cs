using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.Data.Base
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetModified(object entity);
        int SaveChanges(); 

    } 
}
