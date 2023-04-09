﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Downloader.Enums
{
    /// <summary>
    /// The video type. Also known as video container.
    /// </summary>
    public enum VideoType
    {
        /// <summary>
        /// Video for mobile devices (3GP).
        /// </summary>
        Mobile,

        Flash,
        Mp4,
        WebM,

        /// <summary>
        /// The video type is unknown. This can occur if YoutubeExtractor is not up-to-date.
        /// </summary>
        Unknown
    }
}
