using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Видео
    /// </summary>
    public interface IVideo : IAudio
    {
        /// <summary>
        /// Разрешение
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// Формат видео
        /// </summary>
        public string FormatVideo { get; set; }

        /// <summary>
        /// Количество кадров в секунду (FPS)
        /// </summary>
        public string FrameRate { get; set; }
    }
}
