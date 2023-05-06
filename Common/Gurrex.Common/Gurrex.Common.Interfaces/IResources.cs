namespace Gurrex.Common.Interfaces
{
    /// <summary>
    /// Информация о сборке
    /// </summary>
    public interface IResources
    {
        /// <summary>
        /// Тип, вызывающий свойстов <see cref="ResourcesPath"/>
        /// </summary>
        string? TypeName { get; set; }

        /// <summary>
        ///// Путь до ресурсов
        /// </summary>
        string ResourcesPath { get; }
    }
}
