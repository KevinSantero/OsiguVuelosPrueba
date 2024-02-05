namespace Infraestructura.Queries;

using Aplicacion.Queries;
using Domain.Shemas;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

public class AereoliniaQueries : BaseQueries, IAereoliniaQueries
{
    public AereoliniaQueries(IDbConnection connection, Compiler compiler) : base(connection, compiler)
    {
    }

    public async Task<List<AereolineaScheme>> ObtenerAereolinea()
    {
        var query = _queryFactory.Query(TableAereolinia.TableName)
                                 .Select(TableAereolinia.Id, TableAereolinia.Nombre)
                                 .OrderBy(TableAereolinia.Nombre);
        var list = await query.GetAsync<AereolineaScheme>();
        return list.ToList();
    }
}



