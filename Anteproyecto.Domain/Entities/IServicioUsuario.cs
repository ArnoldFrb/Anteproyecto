using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain.Entities
{
    public interface IServicioUsuario
    {
        string Nombres { get; }
        string Apellidos { get;  }
        string NumeroIdentificacion { get; }
        string Correo { get; }
        string Contraseña { get;  }


        string ModificarCorreo(string correo);
        string ModificarContraseña(string contraseña);
    }

    }
