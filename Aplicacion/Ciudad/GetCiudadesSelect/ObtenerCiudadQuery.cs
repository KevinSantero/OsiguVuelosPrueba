using Aplicacion.Abstraciones.Messaging;
using Domain.Shemas;

public sealed record ObtenerCiudadQuery() : IQuery<List<CiudadSchema>>;
