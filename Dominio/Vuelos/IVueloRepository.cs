namespace Dominio.Vuelos
{
    public interface IVueloRepository
    {
        Vuelo ObtenerVueloPorIdAsync(int id);
        Vuelo ObtenerVueloPorNumeroAsync(int numero);

        void Add(Vuelo vuelo);
    }
}
