namespace Infraestructura.Repositorios
{

    using Dominio.Abstracciones;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq.Expressions;


    public class Repository : IRepository, IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        //private readonly IMapper _mapper;

        public DbContext Context { get { return _context; } }


        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //_mapper = mapper;
        }

        #region --Gets--

        public virtual T GetById<T>(object key) where T : class
        {
            return Context.Set<T>().Find(key);
        }

        public virtual T GetById<T>(params object[] keyValues) where T : class
        {
            return Context.Set<T>().Find(keyValues);
        }

        public virtual T Get<T>(Func<T, bool> predicate) where T : class
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public async virtual  Task<T> GetAsync<T>(Expression< Func<T, bool>> predicate, CancellationToken cancellation = default) where T : class
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate, cancellation);
        }

        public virtual T Get<T, W>(Func<T, bool> predicate, Expression<Func<T, W>> include) where T : class where W : class
        {
            return Context.Set<T>().Include(include).FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> GetAll<T>() where T : class
        {
            var result = Context.Set<T>().AsEnumerable().ToList();
            return result;
        }

        public virtual IQueryable<T> Table<T>() where T : class
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// Gets the table no tracking.
        /// </summary>
        /// <value>
        /// The table no tracking.
        /// </value>
        public IQueryable<T> TableNoTracking<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }

        //public virtual IEnumerable<S> GetAll<T, S>() where T : class where S : class
        //{
        //    var result = Context.Set<T>().AsEnumerable<T>();
        //    return _mapper.Map<IEnumerable<T>, IEnumerable<S>>(result);
        //}

        public IEnumerable<T> GetAll<T>(Func<T, bool> predicate) where T : class
        {
            return Context.Set<T>().Where(predicate);
        }
        #endregion

        #region --Adds--
        public virtual EntityEntry<T> Add<T>(T entity) where T : class
        {
            return Context.Set<T>().Add(entity);
        }

        public async virtual Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class
        {
            return await Context.Set<T>().AddAsync(entity);
        }

        public virtual void AddRange<T>(IEnumerable<T> entity) where T : class
        {
            Context.Set<T>().AddRange(entity);
        }
        #endregion

        #region --Updates--
        public virtual EntityEntry<T> Update<T>(T entity) where T : class
        {
            return Context.Set<T>().Update(entity);
        }

        public virtual void UpdateIgnoringProperty<T, W>(T entity, Expression<Func<T, W>> property) where T : class where W : struct
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Entry(entity).Property(property).IsModified = false;
        }

        public void UpdateRange<T>(IEnumerable<T> entity) where T : class
        {
            Context.Set<T>().UpdateRange(entity);
        }
        #endregion

        #region --Delete--
        public virtual EntityEntry<T> Delete<T>(T entity) where T : class
        {
            return Context.Set<T>().Remove(entity);
        }
        #endregion

        #region --IUnitOfWork--
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync( )
        {
            return Context.SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region  --Helpers--
        public virtual T UnProxy<T>(T entity) where T : new()
        {
            var type = entity.GetType();
            if (type.Namespace == "Castle.Proxies")
            {
                var baseType = type.BaseType;
                var returnObject = new T();
                foreach (var property in baseType.GetProperties())
                {
                    var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    if (propertyType.Namespace == "System")
                    {
                        var value = property.GetValue(entity);
                        property.SetValue(returnObject, value);
                    }
                }
                return returnObject;
            }
            return entity;
        }

        public void Detach<T>(T entity) where T : new()
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public async Task<bool> TryDeleteAsync<Table>(Table entity) where Table : class
        {
            try
            {
                Delete(entity);
                await SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                //if (CoreHelper.CheckDataBaseException(e, out string message))
                //{
                //    if (message == DataBaseExceptionMessages.foreign_key_violation)
                //    {
                //        var entries = _context.ChangeTracker.Entries<Table>();
                //        foreach (var entry in entries)
                //            entry.State = EntityState.Detached;
                //    }
                //    return false;
                //}
                throw e;
            }
        }
        #endregion

        #region --IDisposable--
        public void Dispose()
        {
            //_context?.DetachAllEntriesInChangeTracker();
            //_context?.Dispose();
            //_context = null;
            // CoreHelper.WaitForPendingFinalizers();
        }

        
        #endregion
    }
}
