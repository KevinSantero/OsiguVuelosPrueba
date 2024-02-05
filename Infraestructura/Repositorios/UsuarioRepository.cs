namespace Infraestructura.Repositorios
{
    using Dominio.Abstracciones;
    using Dominio.Usuario;

    internal sealed class UsuarioRepository : IUsuarioRepository
    {
        private readonly IRepository _repository;
        public UsuarioRepository(IRepository repository) {
            _repository = repository;
        }

        public async Task<Usuario> ObtenerUsuario(string nombreUsuario, string contrasena, CancellationToken cancellationToken = default)
        {
           var resultado=   await _repository.GetAsync<Usuario>(x =>
                        x.NombreUsuario == nombreUsuario && x.Contrasena == contrasena, cancellationToken);

            return resultado;

        }
        public async Task<Usuario> ObtenerPorId (Guid id, CancellationToken cancellationToken = default)
       => await _repository.GetAsync<Usuario>(x =>x.Id== id,cancellationToken);

    }
}
