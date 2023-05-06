namespace Gurrex.Common.Helpers.Exceptions
{
    /// <summary>
    /// Исключение при несоответствии длины строки
    /// </summary>
    public class RemoveEndToStringException : Exception
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="message">Сообщение</param>
        public RemoveEndToStringException(string message) : base(message)
        {

        }
    }
}
