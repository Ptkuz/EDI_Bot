using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Поток, полученный по ссылки на YouTube
    /// </summary>
    public interface IInfo : IEntity
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; }

    }
}
