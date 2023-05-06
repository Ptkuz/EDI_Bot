namespace Gurrex.Common.Conversion
{
    /// <summary>
    /// Конвертация
    /// </summary>
    public static class ConversionExtentions
    {
        /// <summary>
        /// Получить строку base64 из потока <see cref="Stream"/>
        /// </summary>
        /// <param name="stream">Потомк <see cref="Stream"/> в строку base64</param>
        /// <returns>Строка base64</returns>
        public static string ConvertToBase64(this byte[] bytes)
        {
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
