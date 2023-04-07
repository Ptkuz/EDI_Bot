using System.Diagnostics;
using System.Reflection;

namespace Gurrex.Common.DAL.Base
{
    /// <summary>
    /// Базовый класс текущей сборки
    /// </summary>
    public class BaseDAL
    {
        /// <summary>
        /// Текущая сборка
        /// </summary>
        protected readonly Assembly _currentAssembly = null!;

        /// <summary>
        /// Путь до файлов ресурсов
        /// </summary>
        protected string _resourcesPath = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public BaseDAL() 
        {
            _currentAssembly = Assembly.GetExecutingAssembly();
            _resourcesPath = $"{_currentAssembly.FullName}.Resources";
        }

    }
}
