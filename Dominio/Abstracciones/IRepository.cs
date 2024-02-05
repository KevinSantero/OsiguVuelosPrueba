using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Dominio.Abstracciones
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IRepository : IDisposable
    {
        public DbContext Context { get; }

        #region --Gets--
        T GetById<T>(object key) where T : class;
        T GetById<T>(params object[] keyValues) where T : class;
        T Get<T>(Func<T, bool> predicate) where T : class;

       Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default) where T : class;
       T Get<T, W>(Func<T, bool> predicate, Expression<Func<T, W>> include) where T : class where W : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetAll<T>(Func<T, bool> predicate) where T : class;

        IQueryable<T> Table<T>() where T : class;
        IQueryable<T> TableNoTracking<T>() where T : class;
        #endregion

        #region --Adds--
        EntityEntry<T> Add<T>(T entity) where T : class;
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entity) where T : class;
        #endregion

        #region --Updates--
        EntityEntry<T> Update<T>(T entity) where T : class;
        void UpdateIgnoringProperty<T, W>(T entity, Expression<Func<T, W>> property) where T : class where W : struct;
        void UpdateRange<T>(IEnumerable<T> entity) where T : class;
        #endregion

        #region --Delete--
        EntityEntry<T> Delete<T>(T entity) where T : class;
        #endregion

        #region --IUnitOfWork--
        Task<int> SaveChangesAsync();
        int SaveChanges();
        IDbContextTransaction BeginTransaction();
        #endregion

        #region  -Helpers--
        T UnProxy<T>(T entity) where T : new();
        void Detach<T>(T entity) where T : new();

        Task<bool> TryDeleteAsync<Table>(Table entity) where Table : class;
        #endregion
    }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

}
