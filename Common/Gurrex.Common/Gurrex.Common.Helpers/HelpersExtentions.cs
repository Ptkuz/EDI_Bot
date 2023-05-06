using Gurrex.Common.Helpers.Exceptions;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using System.Reflection;

namespace Gurrex.Common.Helpers
{
    /// <summary>
    /// Хелперы расширения
    /// </summary>
    public static class HelpersExtentions
    {
        /// <summary>
        /// Сборка
        /// </summary>
        private static Assembly currentAssembly = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        private static string fileResourceName = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        static HelpersExtentions()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            fileResourceName = "Gurrex.Common.Helpers.Resources.HelpersExtentions";
        }

        /// <summary>
        /// Удаление подстроки из конца подстроки
        /// </summary>
        /// <param name="info">Строка</param>
        /// <param name="infoType">Подстрока</param>
        /// <returns>Строка без подстроки</returns>
        /// <exception cref="RemoveEndToStringException">Исключение при несоответсвии строки с подстрокой</exception>
        public static string RemoveEndToString(this string info, string infoType)
        {
            try
            {
                if (info.Length < infoType.Length)
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "ExceptionRemoveEndToString", currentAssembly));
                    string errorMessage = String.Format(localizationString, info, infoType);
                    throw new RemoveEndToStringException(errorMessage);
                }

                if (!info.Contains(infoType))
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "ExceptionNoContainsToString", currentAssembly));
                    string errorMessage = String.Format(localizationString, info, infoType);
                    throw new ExceptionNoContainsToString(errorMessage);
                }

                if (String.IsNullOrWhiteSpace(infoType))
                {
                    return info;
                }

                info = info.Remove(info.Length - infoType.Length);
                return info;
            }
            catch (RemoveEndToStringException)
            {
                throw;
            }
            catch (ExceptionNoContainsToString)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Парсинг строки в Int32
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns>Значение Int</returns>
        public static int ParseIntFromString(this string text)
        {
            try
            {
                text.CheckStringForNullOrWhiteSpace();

                bool check = Int32.TryParse(text, out int result);

                if (!check)
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "ExceptionParseIntFromString", currentAssembly));
                    string errorMessage = String.Format(localizationString, nameof(text));
                    throw new FormatException(errorMessage);
                }

                return result;
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
