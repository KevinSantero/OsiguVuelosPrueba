using Dominio.Abstracciones;

namespace Dominio.Usuarios
{
    public static class VueloErrors
    {
        public static Error NotFound = new(
                 "Vuelo.Found",
                 "No existe este vuelo"
             );

        public static Error CreationProgram = new(
            "Vuelo.CreationProgram",
            "Error en en la creacion del vuelo"
        );


        public static Error IdEmpety = new(
            "Vuelo.IdVacio",
            "Debe seleccionar un vuelo"
        );

        public static Error TripComplete = new(
            "Vuelo.TripComplete",
            "Este viaje se encuentra completado"
        );


    }
}
