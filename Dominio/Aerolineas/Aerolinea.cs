using Dominio.Abstracciones;
using Dominio.Vuelos;

namespace Dominio.Aerolineas
{
    public sealed class Aerolinea:BaseEntity<int>
    {
        public string Nombre  { get; set; }
        public  ICollection<Vuelo> Vuelos { get;  private set; }
    }
}
