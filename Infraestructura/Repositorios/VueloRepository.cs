using Dominio.Abstracciones;
using Dominio.Vuelos;
using System.Runtime.CompilerServices;

namespace Infraestructura.Repositorios
{

    internal sealed class VueloRepository : IVueloRepository
    {
        private readonly IRepository _repository;
        public VueloRepository(IRepository repository)
        {
            _repository = repository;
        }
        public Vuelo ObtenerVueloPorIdAsync(int id)
        => _repository.Get<Vuelo>(x => x.Id == id);

        public Vuelo ObtenerVueloPorNumeroAsync(int numero)
          =>  _repository.Get<Vuelo>(x => x.NumeroVuelo == numero);

        public void Add(Vuelo vuelo)
        => _repository.Add(vuelo);

    }
}
