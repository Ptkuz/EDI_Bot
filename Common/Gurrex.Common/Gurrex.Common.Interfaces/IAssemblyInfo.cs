using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces
{
    /// <summary>
    /// Информация о сборке
    /// </summary>
    public interface IAssemblyInfo
    {

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <param name="type">Тип, из которого будет вызвана реализация метода</param>
        /// <returns>Путь до ресурсов</returns>
        string GetResourcesPath(string type);
    }
}
