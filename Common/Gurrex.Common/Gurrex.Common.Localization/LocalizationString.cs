using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Gurrex.Common.Localization
{
    public static class LocalizationString
    {

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
            catch(ArgumentNullException)
            {
                throw;
            }
        }
    }
}