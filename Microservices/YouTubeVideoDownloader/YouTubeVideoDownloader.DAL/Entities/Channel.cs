using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.DAL.Entities.Base;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Сущность канала
    /// </summary>
    public class Channel : Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция видео
        /// </summary>
        public virtual IQueryable<Video> Videos { get; set; } = null!;
    }
}
