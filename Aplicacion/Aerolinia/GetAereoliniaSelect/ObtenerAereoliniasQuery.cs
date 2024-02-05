using Aplicacion.Abstraciones.Messaging;
using Domain.Shemas;

public sealed record ObtenerAereoliniasQuery() : IQuery<List<AereolineaScheme>>;
