﻿using Gurrex.Common.Helpers;
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
    public static class DataInformationHelpers
    {

        /// <summary>
        /// Получить значение по ключу в ссылке
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <param name="key">Ключ</param>
        /// <exception cref="NoContainsKeyException">Исключение, если такого ключа в ссылке нет</exception>
        /// <returns>Значение по ключу в ссылке</returns>
        public static string GetUrlValueByKey(string url, string key)
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
                    string resource = ManagerResources.GetString(new Resource("DataInformationHelpers.ExceptionNoContainsKeyV", StaticHelpers.GetAssemblyInfo().Assembly));
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

        public static string GetSimpleYouTubeUrl(string url) 
        {
            string value = GetUrlValueByKey(url, "v");
            string resource = ManagerResources.GetString(new Resource("DataInformationHelpers.TemplateYouTubeUrl", StaticHelpers.GetAssemblyInfo().Assembly));
            string resultString = ManagerResources.GetResultString(resource, value);
            return resultString;
        }
    }
}
