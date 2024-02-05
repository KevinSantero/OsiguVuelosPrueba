namespace Aplicacion.Abstraciones.Messaging;

using Dominio.Abstracciones;
using MediatR;
public interface IQueryHandler<TQuery, TResponse> 
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}