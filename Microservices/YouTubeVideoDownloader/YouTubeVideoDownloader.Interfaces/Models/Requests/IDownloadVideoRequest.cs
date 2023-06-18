using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.Interfaces.Models.Requests
{
    public interface IDownloadVideoRequest : IBaseModel
    {
        /// <summary>
        /// Ссылка на видео
        /// </summary>
        [DataMember]
        string Url { get; set; }

        /// <summary>
        /// Аудио битрейт
        /// </summary>
        [DataMember]
        string AudioBitrate { get; set; }

        /// <summary>
        /// Разрешение
        /// </summary>
        [DataMember]
        string? Resolution { get; set; }

        /// <summary>
        /// Аудио формат
        /// </summary>
        [DataMember]
        string AudioFormat { get; set; }

        /// <summary>
        /// Видео формат
        /// </summary>
        [DataMember]
        string? VideoFormat { get; set; }

        /// <summary>
        /// Fps
        /// </summary>
        [DataMember]
        string? Fps { get; set; }

        /// <summary>
        /// Конвертировать строку в Int
        /// </summary>
        /// <param name="text">Строка</param>
        /// <param name="infoType">Подстрока, которую нужно удалить</param>
        /// <returns>Значение Int</returns>
        int ConvertToInt(string text, string infoType = "");

        /// <summary>
        /// Конвертировать строку в <see cref="AudioFormat"/>
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns><see cref="AudioFormat"/></returns>
        AudioFormat ConvertToAudioFormat(string text);

        /// <summary>
        /// Ковертировать строку в <see cref="VideoFormat"/>
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns><see cref="VideoFormat"/></returns>
        VideoFormat ConvertToVideoFormat(string text);
    }
}
