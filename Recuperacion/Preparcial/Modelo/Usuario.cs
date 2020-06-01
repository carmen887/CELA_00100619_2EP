namespace Preparcial.Modelo
{
    public class Usuario
    {
        public string IdUsuario { get; set; }

        public string NombreUsuario { get; set; }
        
        //Correccion: cambiar "contrasena" por "contrasenia"
        public string Contrasenia { get; set; }

        public bool Admin { get; set; }

        public Usuario(string idUsuario, string nombreUsuario, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Admin = admin;
        }
    }
}
