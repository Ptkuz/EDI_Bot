using System.Reflection;

namespace Gurrex.Common.Interfaces
{
    /// <summary>
    /// Информация о сборке
    /// </summary>
    public interface IResources<T> : IAssembly<T> where T : class
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        string ResourcesPath { get; }

    }
}
