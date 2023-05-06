﻿using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using System.Diagnostics;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Аудио поток
    /// </summary>
    public class Audio : Entity, IAudio
    {

        /// <summary>
        /// Имя типа, вызывающий свойство <see cref="ResourcesPath"/>
        /// </summary>
        public override string? TypeName { get; set; }

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get
            {
                if (TypeName is not nameof(Audio)) 
                {
                    return base.ResourcesPath;
                }

                return $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.Audio";
            }
        }


        /// <summary>
        /// Формат
        /// </summary>
        [Column("FormatAudio", Order = 4)]
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Битрейт
        /// </summary>
        [Column("Bitrate", Order = 5)]
        public string Bitrate { get; set; } = null!;

        /// <summary>
        /// YouTube поток
        /// </summary>
        [ForeignKey("YouTubeInfoId")]
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Информация о аудио на сервере
        /// </summary>
        [ForeignKey("ServerInfoId")]
        public ServerInfo ServerInfo { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Audio() 
        {

        }

        /// <summary>
        /// Инициализатор конструктор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="formatAudio">Формат аудио</param>
        /// <param name="bitrate">Битрейт</param>
        public Audio(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string formatAudio, string bitrate) 
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            FormatAudio = formatAudio;
            Bitrate = bitrate;
        }


    }
}
