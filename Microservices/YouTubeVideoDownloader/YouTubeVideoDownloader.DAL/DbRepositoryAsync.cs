using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities.Base;
using YouTubeVideoDownloader.Interfaces.Interfaces.Repository;

namespace YouTubeVideoDownloader.DAL
{
    public class DbRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : Entity, new()
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entities;    

        private bool autoSaveChanges = true;

        public DbRepositoryAsync(DownloaderContext dbContext) 
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }


        public IQueryable<T> Items => _entities;

        public Task<bool> AddEntityAsync(T entity, CancellationToken cancel = default)
        {
            throw new Exception();
        }

        public Task<bool> DeleteEntityById(Guid id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task<T>? GetEntityByIdAsync(Guid id, CancellationToken cancel = default)
        {
            try
            {
                T? item = await Items.SingleOrDefaultAsync(item => item.Id == id);
                item.CheckObjectForNull(nameof(item));
                return item;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public Task<T> GetLastEntityAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(T entity, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
