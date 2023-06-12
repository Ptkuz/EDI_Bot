using Gurrex.Common.Helpers;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Localization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YouTubeVideoDownloader.YouTubeDataOperations.Exceptions;
using Gurrex.Common.Validations;
using Gurrex.Common.Helpers.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Helpers
{
    /// <summary>
    /// Хелперы DataInformation
    /// </summary>
    internal class DataInformationHelpers
    {
        /// <summary>
        /// Сборка
        /// </summary>
        internal static AssemblyInfo AssemblyInfo { get; set; }

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        internal static string ResourcesPath { get; set; }

        static DataInformationHelpers() 
        {
            AssemblyInfo = StaticHelpers.GetAssemblyInfo();
            ResourcesPath = $"{AssemblyInfo.AssemblyName.Name}.Resources.Helpers.DataInformationHelpers";
        }

        /// <summary>
        /// Получить значение по ключу в ссылке
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <param name="key">Ключ</param>
        /// <exception cref="NoContainsKeyException">Исключение, если такого ключа в ссылке нет</exception>
        /// <returns>Значение по ключу в ссылке</returns>
        internal static string GetUrlValueByKey(string url, string key)
        {
            try
            {
                Uri uri = new Uri(url);
                NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);

                query.CheckObjectForNull(nameof(query));

                if (query.AllKeys.Contains(key))
                    return query[key];
                else
                {
                    string resource = ManagerResources.GetString(new Resource(ResourcesPath, "ExceptionNoContainsKeyV", AssemblyInfo.Assembly));
                    string resultString = ManagerResources.GetResultString(resource, url);
                    throw new NoContainsKeyException(resultString, key);
                }
            }
            catch (NoContainsKeyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static string GetSimpleYouTubeUrl(string url) 
        {
            string value = GetUrlValueByKey(url, "v");
            string resource = ManagerResources.GetString(new Resource(ResourcesPath, "TemplateYouTubeUrl", AssemblyInfo.Assembly));
            string resultString = ManagerResources.GetResultString(resource, value);
            return resultString;
        }
    }
}
