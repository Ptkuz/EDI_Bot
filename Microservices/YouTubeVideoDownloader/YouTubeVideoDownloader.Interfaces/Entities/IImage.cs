using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    public interface IImage : IEntity
    {
        /// <summary>
        /// Массив байтов картинки
        /// </summary>
        byte[] ImageBytes { get; set; }

        /// <summary>
        /// Расширение картинки
        /// </summary>
        string Extention { get; set; }
    }
}
