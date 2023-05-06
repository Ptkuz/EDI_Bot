using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Gurrex.Common.Validations
{
    /// <summary>
    /// Расширения для валидации
    /// </summary>
    public static class ExtentionsCommonValidations
    {

        private static Assembly currentAssembly = null!;
        private static string fileResourceName = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        static ExtentionsCommonValidations()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            fileResourceName = "Gurrex.Common.Validations.Resources.ExtentionsCommonValidations";
        }

        /// <summary>
        /// Проверить <see cref="object"/> на null
        /// </summary>
        /// <param name="value">класс, унаследованный от <see cref="object"/></param>
        /// <param name="argument">Аргумент исключения</param>
        /// <exception cref="ArgumentNullException">Один из параметров метода пустой</exception>
        public static void CheckObjectForNull([NotNull] this object? value, string argument)
        {
            try
            {
                argument.CheckStringForNullOrWhiteSpace();
                if (value is null)
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "ExceptionCheckValueForNull", currentAssembly));
                    string errorMessage = String.Format(localizationString, argument);
                    throw new ArgumentNullException(argument, errorMessage);
                }
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
        /// Проверка строки на null и пустое пространство
        /// </summary>
        /// <param name="text"></param>
        public static void CheckStringForNullOrWhiteSpace([NotNull] this string? text) 
        {
            try
            {
                if (String.IsNullOrWhiteSpace(text))
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "ExceptionCheckStringForNullOrEmpty", currentAssembly));
                    string errorMessage = String.Format(localizationString, nameof(text));
                    throw new ArgumentNullException(nameof(text), errorMessage);
                }
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
    }
}
