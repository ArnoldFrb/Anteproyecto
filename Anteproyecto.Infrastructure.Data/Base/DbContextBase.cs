using Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Infrastructure.Data.Base
{
    public class DbContextBase : DbContext, IDbContext
    {

        public DbContextBase()
        {

        }
        public DbContextBase(DbContextOptions options) : base(options)
        {

        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }


    }

}
