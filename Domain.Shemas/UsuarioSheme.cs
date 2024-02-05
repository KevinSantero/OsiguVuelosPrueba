namespace Domain.Shemas
{
    public sealed class UsuarioSheme
    {
        public string NombreUsuario { get;  set; }

        public string Email { get;  set; }

        public string NombreCompleto { get;  set; }

        public string Rol { get; set; } = "Administrador";

    }
}
