namespace Aplicacion.Abstraciones.Messaging;

using Dominio.Abstracciones;
using MediatR;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}