using Aplicacion.Exepciones;
using Dominio.Abstracciones;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructura.Repositorios
{
    public class ContainerUnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private readonly IPublisher _publisher;

        public ContainerUnitOfWork(ApplicationDbContext context, IPublisher publisher)
        {
            this._context = context;
            _publisher = publisher;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public  async Task<int> SaveChangesAsync(
          CancellationToken cancellationToken = default
          )
        {
            try
            {
                var result = await _context.SaveChangesAsync(cancellationToken);

                await PublishDomainEventsAsync();

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        #region --IDisposable--
        public void Dispose()
        {
            //_context?.DetachAllEntriesInChangeTracker();
            //_context?.Dispose();
            //_context = null!;
            //CoreHelper.WaitForPendingFinalizers();
        }


        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = _context.ChangeTracker
                .Entries<BaseEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return domainEvents;
                }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }

        }

        #endregion
    }
}
