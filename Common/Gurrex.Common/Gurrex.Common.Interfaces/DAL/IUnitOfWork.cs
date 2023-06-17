using Gurrex.Common.Interfaces.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.DAL
{
    public interface IUnitOfWork : IDisposable 
    {
        T GetEntityRepository<T, K>(Type repositoryType)
            where T : class, IEntityRepository<K>
            where K : class, IEntity, new();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
