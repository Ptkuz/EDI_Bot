﻿using Gurrex.Common.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Поток, полученный по ссылки на YouTube
    /// </summary>
    public interface IYouTubeInfo : IEntity
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
