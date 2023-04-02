using Gurrex.Common.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Repositories.Async;

namespace YouTubeVideoDownloader.DAL.Repositories.Async
{
    /// <summary>
    /// Ассинхронный репозиторий работы с <see cref="Channel"/>
    /// </summary>
    public class ChannelRepositoryAsync : DbRepositoryAsync<Channel>, IChannelRerositoryAsync<Channel>
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        public ChannelRepositoryAsync(DownloaderContext dbContext) : base(dbContext)
        {

        }
    }
}
