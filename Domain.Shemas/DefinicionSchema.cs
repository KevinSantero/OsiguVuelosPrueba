using Domain.Shemas.Core;

namespace Domain.Shemas
{
	
	public static class TableCiudad
    {
        public static readonly string TableName = DataBaseSchema.BuildTableName("Ciudades");
        public static readonly string Id = TableName + ".Id";
        public static readonly string Nombre = TableName + ".Nombre";
    }

    public static class TableAereolinia
    {
        public static readonly string TableName = DataBaseSchema.BuildTableName("Aereolinias");
        public static readonly string Id = TableName + ".Id";
        public static readonly string Nombre = TableName + ".Nombre";
    }


    public static class ViewVuelos
    {
        public static readonly string TableName = DataBaseSchema.BuildTableName("VmVuelos");
        public static readonly string Id = TableName + ".Id";
        public static readonly string NumeroVuelo = TableName + ".NumeroVuelo";
        public static readonly string CiudadOrigenId = TableName + ".CiudadOrigenId";
        public static readonly string CiudadOrigen = TableName + ".CiudadOrigen";
        public static readonly string CiudadDestinoId = TableName + ".CiudadDestinoId";
        public static readonly string CiudadDestino = TableName + ".CiudadDestino";
        public static readonly string Fecha = TableName + ".Fecha";
        public static readonly string HoraSalida = TableName + ".HoraSalida";
        public static readonly string HoraLlegada = TableName + ".HoraLlegada";
        public static readonly string AerolineaId = TableName + ".AerolineaId";
        public static readonly string NombreAerolinia = TableName + ".NombreAerolinia";
        public static readonly string Estado = TableName + ".Estado";
        public static readonly string UsuarioCreacionId = TableName + ".UsuarioCreacionId";
        public static readonly string UsuarioCreacion = TableName + ".UsuarioCreacion";
        public static readonly string UsuarioActualizacionId = TableName + ".UsuarioActualizacionId";
        public static readonly string UsuarioActualizacion = TableName + ".UsuarioActualizacion";
        public static readonly string FechaCreacion = TableName + ".FechaCreacion";
        public static readonly string FechaActualizacion = TableName + ".FechaActualizacion";
    }
}

