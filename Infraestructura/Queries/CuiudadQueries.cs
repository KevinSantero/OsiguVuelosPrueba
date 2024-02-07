namespace Infraestructura.Queries;
   
    using Aplicacion.Queries;
    using Domain.Shemas;
    using SqlKata;
    using SqlKata.Compilers;
    using SqlKata.Execution;
    using System.Data;

    internal class CuiudadQueries : BaseQueries, ICiudadQueries
    {
        public CuiudadQueries(IDbConnection connection, Compiler compiler) : base(connection, compiler)
        {
        }
        public async Task<List<CiudadSchema>> ObtenerCiudades()
        {
            var query = _queryFactory.Query(TableCiudad.TableName)
                                .Select(TableCiudad.Id, TableCiudad.Nombre)
                                  .OrderBy(TableCiudad.Nombre);
            var list = await query.GetAsync<CiudadSchema>();
            return list.ToList();
        }
    }

