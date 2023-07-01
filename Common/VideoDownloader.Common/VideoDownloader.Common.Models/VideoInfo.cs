﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VideoDownloader.Common.Models
{

    /// <summary>
    /// Информация о YouTube ролике, полученном по ссылке
    /// </summary>
    public class VideoInfo
    {
        /// <summary>
        /// Главная информация о видео
        /// </summary>
        [DataMember]
        public MainInfo MainInfo { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио битрейтов
        /// </summary>
        [DataMember]
        public IEnumerable<string> AudioBitrates { get; set; } = null!;

        /// <summary>
        /// Пееречисление доступных
        /// </summary>
        [DataMember]
        public IEnumerable<string> Resolutions { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных аудио форматов
        /// </summary>
        [DataMember]
        public IEnumerable<string> AudioFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление видео форматов
        /// </summary>
        [DataMember]
        public IEnumerable<string> VideoFormats { get; set; } = null!;

        /// <summary>
        /// Перечисление доступных Fps
        /// </summary>
        [DataMember]
        public IEnumerable<string> Fps { get; set; } = null!;

        /// <summary>
        /// Картинка в формате Base64
        /// </summary>
        [DataMember]
        public byte[] Image { get; set; } = null!;

        public VideoInfo()
            : base()
        {

        }

        public VideoInfo(Exception exception, string errorMessage)
             : base(exception, errorMessage)
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="mainInfo">Главная информация о видео</param>
        /// <param name="audioBitrates">Перечисление аудио битрейтов</param>
        /// <param name="resolutions">Перечисление разрешений</param>
        /// <param name="audioFormats">Перечисление аудио форматов</param>
        /// <param name="videoFormats">Перечислене видео форматов</param>
        /// <param name="fps">Перечислене Fps</param>
        /// <param name="image">Массив байтов картинки</param>
        public VideoInfo(MainInfo mainInfo, IEnumerable<string> audioBitrates, IEnumerable<string> resolutions, IEnumerable<string> audioFormats, IEnumerable<string> videoFormats, IEnumerable<string> fps, byte[] image)
           : base()
        {
            MainInfo = mainInfo;
            AudioBitrates = audioBitrates;
            Resolutions = resolutions;
            AudioFormats = audioFormats;
            VideoFormats = videoFormats;
            Fps = fps;
            Image = image;
        }
    }
}
}
