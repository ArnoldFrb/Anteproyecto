using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
