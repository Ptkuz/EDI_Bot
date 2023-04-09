using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Exceptions
{
    /// <summary>
    /// Исключение, если не нашлось значение по ключу в ссылке
    /// </summary>
    internal class NoContainsKeyException : Exception
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="key">Ключ</param>
        public NoContainsKeyException(string message, string key)
            : base(message)
        {
            Key = key;
        }
    }
}
