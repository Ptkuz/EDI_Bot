using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Gurrex.Common.Localization
{
    /// <summary>
    /// Локализируемые строки
    /// </summary>
    public static class LocalizationString
    {
        /// <summary>
        /// Получить локализируемую строку
        /// </summary>
        /// <param name="fileResourceName">Имя файла ресурса</param>
        /// <param name="currentAssembly">Имя сборки, где лежит ресурс</param>
        /// <param name="resourceName">Имя ресурса</param>
        /// <exception cref="ArgumentNullException">Значение локализируемой строки не может быть равно null</exception>
        /// <returns>Локализируемая строка</returns>
        public static string GetString(string fileResourceName, Assembly currentAssembly, string resourceName)
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager(fileResourceName, currentAssembly);
                string? value = resourceManager.GetString(resourceName, CultureInfo.CurrentCulture);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Value localization string can not be null");
                }
                return value;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch(Exception) 
            {
                throw;
            }
        }

        /// <summary>
        /// Получить результирующую локализируемую строку
        /// </summary>
        /// <param name="localizationString">Локализируемая строка</param>
        /// <param name="args">Аргументы</param>
        /// <returns>Результирующая локализируемая строка</returns>
        public static string GetResultString(string localizationString, params object[] args)
        {
            return String.Format(localizationString, args);
        }
    }
}