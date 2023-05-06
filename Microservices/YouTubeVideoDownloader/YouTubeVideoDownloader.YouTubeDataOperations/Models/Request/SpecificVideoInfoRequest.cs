using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using VideoLibrary;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Request
{
    /// <summary>
    /// Информация о конкретном видео
    /// </summary>
    public class SpecificVideoInfoRequest : BaseModel
    {

        /// <summary>
        /// Тип, из которого брать ресурсы
        /// </summary>
        public override string? TypeName { get; set; } = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath
        {
            get =>
                 TypeName is not nameof(SpecificVideoInfoRequest) ?
                    base.ResourcesPath :
                    $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Request.SpecificVideoInfoRequest";
        }

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// Аудио битрейт
        /// </summary>
        public string AudioBitrate { get; set; } = null!;

        /// <summary>
        /// Разрешение
        /// </summary>
        public string Resolution { get; set; } = null!;

        /// <summary>
        /// Аудио формат
        /// </summary>
        public string AudioFormat { get; set; } = null!;

        /// <summary>
        /// Видео формат
        /// </summary>
        public string VideoFormat { get; set; } = null!;

        /// <summary>
        /// Fps
        /// </summary>
        public string Fps { get; set; } = null!;

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
                bool check = Enum.TryParse<AudioFormat>(text, out AudioFormat audioFormat);

                if (!check)
                {
                    string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "ExceptionParseEnum", StaticHelpers.GetAssemblyInfo().Assembly));
                    string errorMessage = String.Format(localizationString, nameof(text));
                    throw new FormatException(errorMessage);
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
                bool check = Enum.TryParse<VideoFormat>(text, out VideoFormat audioFormat);

                if (!check)
                {
                    string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "ExceptionParseEnum", StaticHelpers.GetAssemblyInfo().Assembly));
                    string errorMessage = String.Format(localizationString, nameof(text));
                    throw new FormatException(errorMessage);
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
