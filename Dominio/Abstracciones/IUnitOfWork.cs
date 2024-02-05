using Microsoft.EntityFrameworkCore.Storage;

namespace Dominio.Abstracciones{ 
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        IDbContextTransaction BeginTransaction();
    }
}
