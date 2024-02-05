namespace Infraestructura.Queries;

using Aplicacion.Queries;
using Domain.Shemas;
using Dominio.Vuelos;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class VuelosQueries : BaseQueries, IVueloQueries
{
    public VuelosQueries(IDbConnection connection, Compiler compiler) : base(connection, compiler)
    {
    }
    public async Task<VueloScheme?> ObtenerDetalleVuelo(int vueloId)
    {
        var query = _queryFactory.Query(ViewVuelos.TableName)
                                 .Select(ViewVuelos.Id,
                                         ViewVuelos.NumeroVuelo,
                                         ViewVuelos.CiudadOrigen,
										 ViewVuelos.CiudadOrigenId,
										 ViewVuelos.CiudadDestino,
									     ViewVuelos.CiudadDestinoId,
										 ViewVuelos.NombreAerolinia,
										 ViewVuelos.AerolineaId,
										 ViewVuelos.Fecha,
										 ViewVuelos.HoraSalida,
										 ViewVuelos.HoraLlegada,
										 ViewVuelos.Estado,
                                         ViewVuelos.UsuarioActualizacionId,
										 ViewVuelos.UsuarioCreacion,
										 ViewVuelos.UsuarioActualizacionId,
										 ViewVuelos.UsuarioActualizacion,
										 ViewVuelos.FechaCreacion,
										 ViewVuelos.UsuarioActualizacion)
                                 .Where(ViewVuelos.Id, vueloId);
        var resultado = await query.GetAsync<VueloScheme>();
        return resultado.FirstOrDefault();
    }

    public async Task<List<VuelosScheme>> ObtenerVuelos(VueloEstado estado)
    {
        var query = _queryFactory.Query(ViewVuelos.TableName)
                           .Select( ViewVuelos.Id,	 ViewVuelos.NumeroVuelo,
								    ViewVuelos.CiudadOrigen,ViewVuelos.CiudadDestino,
									ViewVuelos.NombreAerolinia,	 ViewVuelos.Fecha,
									ViewVuelos.HoraSalida,ViewVuelos.HoraLlegada,
								    ViewVuelos.Estado,ViewVuelos.UsuarioCreacion,ViewVuelos.FechaCreacion)
                           .Where(ViewVuelos.Estado, (int)estado);
        var resultado = await query.GetAsync<VuelosScheme>();
        return resultado.ToList();
    }

    public async Task<List<VuelosScheme>> ObtenerVuelos()
    {
        var query = _queryFactory.Query(ViewVuelos.TableName)
                          .Select(
			                             ViewVuelos.Id,
										 ViewVuelos.NumeroVuelo,
										 ViewVuelos.CiudadOrigen,
										 ViewVuelos.CiudadDestino,
										 ViewVuelos.NombreAerolinia,
										 ViewVuelos.Fecha,
										 ViewVuelos.HoraSalida,
										 ViewVuelos.HoraLlegada,
										 ViewVuelos.Estado,
										 ViewVuelos.UsuarioCreacion,
										 ViewVuelos.FechaCreacion);
                         
        var resultado = await query.GetAsync<VuelosScheme>();
        return resultado.ToList();
    }
}



