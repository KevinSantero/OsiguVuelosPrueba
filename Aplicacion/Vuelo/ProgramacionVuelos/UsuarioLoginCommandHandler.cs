using Aplicacion.Abstraciones.Messaging;
using Aplicacion.Vuelo.ProgramacionVuelos;
using Dominio.Abstracciones;
using Dominio.Usuario;
using Dominio.Usuarios;
using Dominio.Vuelos;
using System.Transactions;

namespace Aplicacion.Usuario.Login
{
    internal class ProgramacionVueloCommandHandler : ICommandHandler<ProgramacionVueloCommand, int>
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProgramacionVueloCommandHandler(IVueloRepository vueloRepository, IUnitOfWork unitOfWork)
        {
            _vueloRepository = vueloRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(ProgramacionVueloCommand request, CancellationToken cancellationToken)
        {
            var vuelo = Dominio.Vuelos.Vuelo.Programar(
                request.CiudadOrigenId,
                request.CiudadDestinoId,
                request.Fecha,
                request.HoraSalida,
                request.HoraLlegada,
                request.AeroliniaId,
                request.UsuarioCreacionId);

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    _vueloRepository.Add(vuelo);
                    _ = await _unitOfWork.SaveChangesAsync(cancellationToken);

                    scope.Complete();

                    Console.WriteLine("Vuelo creado correctamente");
                }
                catch (TransactionException ex)
                {
                    Console.WriteLine(ex.Message);
                    return Result.Failure<int>(VueloErrors.CreationProgram);
                }
            }

            return Result.Success(vuelo.Id);
        }


       }
    }
