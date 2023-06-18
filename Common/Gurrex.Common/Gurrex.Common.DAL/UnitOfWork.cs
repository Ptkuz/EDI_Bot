using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Interfaces.DAL;
using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Gurrex.Common.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        protected readonly ILogger<UnitOfWork> _logger;
        protected readonly ILogger<EntityRepository<Entity>> _loggerRepository;
        protected bool disposed;
        protected Dictionary<string, object> repositories;


        protected UnitOfWork(DbContext dbContext, ILogger<UnitOfWork> logger, ILogger<EntityRepository<Entity>> loggerRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _loggerRepository = loggerRepository;
        }

        public T GetEntityRepository<T, K>(Type repositoryType)
            where T : class, IEntityRepository<K>
            where K : class, IEntity, new()
        {
            if (repositories is null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(K).Name;

            if (!repositories.ContainsKey(type))
            {
                if (typeof(T).Name != repositoryType.Name) 
                {
                    string errorMessage = ManagerResources.GetString(new Resource("UnitOfWork.ExceptionNotEqualsTypesRepositories", StaticHelpers.GetAssemblyInfo().Assembly));
                    string resultString = ManagerResources.GetResultString(errorMessage, nameof(T), nameof(repositoryType));
                    _logger.LogDebug(resultString);
                    throw new TypeUnloadedException(errorMessage);
                }

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(K)), _dbContext, _loggerRepository);
                repositories.Add(type, repositoryInstance);
            }
            return (T)repositories[type];
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}
