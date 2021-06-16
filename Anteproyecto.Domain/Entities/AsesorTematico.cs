namespace Anteproyecto.Domain
{
    internal class AsesorTematico : Usuario
    {
        public AsesorTematico(string nombres, string apellidos, string numeroIdentificacion, string correo, string contraseña) : base(nombres, apellidos, numeroIdentificacion, correo, contraseña)
        {
        }

        public override string ModificarContrasena(string contraseña)
        {
            throw new System.NotImplementedException();
        }

        public override string ModificarCorreo(string correo)
        {
            throw new System.NotImplementedException();
        }
    }
}