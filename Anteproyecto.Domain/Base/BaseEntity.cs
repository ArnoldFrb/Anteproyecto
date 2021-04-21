using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
