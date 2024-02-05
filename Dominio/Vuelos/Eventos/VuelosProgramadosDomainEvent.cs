using Dominio.Abstracciones;

namespace Dominio.Vuelos.Eventos
{
    public sealed record VuelosProgramadosDomainEvent(int vueloId) : IDomainEvent;
   
}
