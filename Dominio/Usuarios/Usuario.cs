namespace Dominio.Usuario
{
    using Dominio.Abstracciones;
    using Dominio.Vuelos;

    public  class Usuario:BaseEntity<Guid>
    {
        public string NombreUsuario { get; private set; }

        public string Contrasena { get; private set; }

        public string Email { get; private set; }

        public string NombreCompleto { get; private set; }

        public ICollection<Vuelo> VueloUsuaioCreacion { get; set; }
        public ICollection<Vuelo> VueloUsuaioActualizacion { get; set; }

    }
}
