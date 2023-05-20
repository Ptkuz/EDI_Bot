namespace Gurrex.Common.Interfaces
{
    /// <summary>
    /// Информация о сборке
    /// </summary>
    public interface IResources : IAssembly
    {

        /// <summary>
        ///// Путь до ресурсов
        /// </summary>
        string ResourcesPath { get; }

    }
}
