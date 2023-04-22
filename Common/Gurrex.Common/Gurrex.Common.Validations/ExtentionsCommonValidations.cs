using Gurrex.Common.Localization;
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

                if (argument is null)
                {
                    string localizationString = LocalizationString.GetString(fileResourceName, currentAssembly, "ExceptionCheckArgumentForNullOrEmpty");
                    string errorMessage = String.Format(localizationString, nameof(argument));
                    throw new ArgumentNullException(nameof(argument), errorMessage);
                }

                if (value is null)
                {
                    string localizationString = LocalizationString.GetString(fileResourceName, currentAssembly, "ExceptionCheckValueForNull");
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
    }
}
