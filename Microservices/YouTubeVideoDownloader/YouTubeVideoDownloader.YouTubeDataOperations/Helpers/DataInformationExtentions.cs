using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using SixLabors.ImageSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Helpers
{

    /// <summary>
    /// Методы расширения
    /// </summary>
    public static class DataInformationExtentions
    {
        /// <summary>
        /// Конвертировать коллекцию из int в string
        /// </summary>
        /// <param name="collection">Перечисление информации</param>
        /// <param name="infoType">Тип информации</param>
        /// <returns>Список в виде строк</returns>
        public static List<string> ConvertToString<T>(this IEnumerable<T> collection, string infoType = "")
        {
            List<string> collectionString = new List<string>();
            collection.ToList().ForEach(x => collectionString.Add($"{x}{infoType}"));
            return collectionString;
        }
    }
}
