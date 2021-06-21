using Anteproyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anteproyecto.Domain.Contracts
{
    public interface IServicioUsuario
    {
        string Nombres { get; }
        string Apellidos { get;  }
        string NumeroIdentificacion { get; }
        string Correo { get; }
        string Contraseña { get;  }
        int Semestre { get;}
        int Edad { get;  }
        bool Estado { get; }

        string ModificarCorreo(string correo);
        string ModificarContrasena(string contraseña);

        string ValidarUsuario(Usuario usuario);
    }

    }
