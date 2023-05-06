namespace Gurrex.Common.Helpers.Exceptions
{
    /// <summary>
    /// Подстрока не содержится в строке
    /// </summary>
    public class ExceptionNoContainsToString : Exception
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="message">Сообщение</param>
        public ExceptionNoContainsToString(string message) : base(message)
        {

        }
    }
}
