namespace Dominio.Ciudades
{
    using Dominio.Abstracciones;
    using Dominio.Vuelos;

    public sealed class Ciudad : BaseEntity<int>
    {
        public string  Nombre { get; private set; }
        public  ICollection<Vuelo> VuelosOrigen { get; private set; }
        public ICollection<Vuelo> VuelosDestino { get; private set; }
    }
}
