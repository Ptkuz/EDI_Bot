using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Entities
{

    /// <summary>
    /// Канал
    /// </summary>
    public interface IChannel : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

    }
}
