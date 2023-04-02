using Gurrex.Common.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Validations
{
    public static class ExtentionsCommonValidations
    {

        private static Assembly currentAssembly = null!;
        private static string fileResourceName = null!;

        static ExtentionsCommonValidations() 
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            fileResourceName = "Gurrex.Common.Validations.Resources.ExtentionsCommonValidations";
        }

        public static void CheckObjectForNull(this object? value, string argument) 
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
        }
    }
}
