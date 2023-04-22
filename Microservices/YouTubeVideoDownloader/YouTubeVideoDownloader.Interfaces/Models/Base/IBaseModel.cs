using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Models.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public interface IBaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        Guid Id { get; set; }
    }
}
