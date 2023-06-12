using Gurrex.Common.Localization.Models;
using System.Globalization;
using System.Resources;

namespace Gurrex.Common.Localization
{
    /// <summary>
    /// Локализируемые строки
    /// </summary>
    public static class ManagerResources
    {
        /// <summary>
        /// Получить строку из файла ресурсов
        /// </summary>
        /// <param name="resource">Ресурс</param>
        /// <returns>Строка из файла ресурсов</returns>
        public static string GetString(Resource resource)
        {
            try
            {
                string[] resources = resource.Assembly.GetManifestResourceNames();
                var culture = CultureInfo.CurrentUICulture.Name;
                ResourceManager resourceManager = new ResourceManager(resource.FileResourceName, resource.Assembly);
                string? value = resourceManager.GetString(resource.ResourceName, CultureInfo.CurrentCulture);

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
            catch (Exception)
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