namespace Dominio.Usuario
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerUsuario(string nombreUsuario, string contrasena, CancellationToken cancellationToken = default);
        Task<Usuario> ObtenerPorId(Guid id, CancellationToken cancellationToken = default);
    }
}
 