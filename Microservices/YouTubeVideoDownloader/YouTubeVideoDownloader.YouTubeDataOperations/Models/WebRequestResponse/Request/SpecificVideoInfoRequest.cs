using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using VideoLibrary;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.WebRequestResponse.Request
{
    /// <summary>
    /// Информация о конкретном видео
    /// </summary>
    [DataContract]
    public class SpecificVideoInfoRequest : BaseModel
    {

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        [DataMember]
        public string Url { get; set; } = null!;

        /// <summary>
        /// Аудио битрейт
        /// </summary>
        [DataMember]
        public string AudioBitrate { get; set; } = null!;

        /// <summary>
        /// Разрешение
        /// </summary>
        [DataMember]
        public string? Resolution { get; set; }

        /// <summary>
        /// Аудио формат
        /// </summary>
        [DataMember]
        public string AudioFormat { get; set; } = null!;

        /// <summary>
        /// Видео формат
        /// </summary>
        [DataMember]
        public string? VideoFormat { get; set; }

        /// <summary>
        /// Fps
        /// </summary>
        [DataMember]
        public string? Fps { get; set; }

        /// <summary>
        /// Конвертировать строку в Int
        /// </summary>
        /// <param name="text">Строка</param>
        /// <param name="infoType">Подстрока, которую нужно удалить</param>
        /// <returns>Значение Int</returns>
        public int ConvertToInt(string text, string infoType = "")
        {
            string value = text.RemoveEndToString(infoType);
            int result = value.ParseIntFromString();
            return result;
        }

        /// <summary>
        /// Конвертировать строку в <see cref="AudioFormat"/>
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns><see cref="AudioFormat"/></returns>
        public AudioFormat ConvertToAudioFormat(string text)
        {
            try
            {
                bool check = Enum.TryParse(text, out AudioFormat audioFormat);

                if (!check)
                {
                    throw new FormatException($"Failed to parse value {text}");
                }

                return audioFormat;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ковертировать строку в <see cref="VideoFormat"/>
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns><see cref="VideoFormat"/></returns>
        public VideoFormat ConvertToVideoFormat(string text)
        {
            try
            {
                bool check = Enum.TryParse(text, out VideoFormat audioFormat);

                if (!check)
                {
                    throw new FormatException($"Failed to parse value {text}");
                }

                return audioFormat;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
