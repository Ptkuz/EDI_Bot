using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    public interface IChannel : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

    }
}
