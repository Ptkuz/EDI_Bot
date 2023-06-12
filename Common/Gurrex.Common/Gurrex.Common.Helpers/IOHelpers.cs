using Gurrex.Common.Localization.Models;
using Gurrex.Common.Localization;
using Gurrex.Common.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gurrex.Common.Helpers
{
    /// <summary>
    /// Хелперы для работы с пространством имен <see cref="System.IO"/>
    /// </summary>
    public static class IOHelpers
    {

        /// <summary>
        /// Сборка
        /// </summary>
        private static Assembly currentAssembly = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        private static string fileResourceName = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        static IOHelpers()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            fileResourceName = "Gurrex.Common.Helpers.Resources.IOHelpers";
        }

        /// <summary>
        /// Собрать путь из аргументов
        /// </summary>
        /// <param name="checkFileExist">Проверить существование файла</param>
        /// <param name="checkDirectoryExist">Проверить существование директории</param>
        /// <param name="arguments">Аргументы</param>
        /// <returns>Сформированный путь</returns>
        public static string PathCombine(bool checkFileExist = false, bool checkDirectoryExist = false, params string[] arguments) 
        {
            try
            {
                foreach (var item in arguments)
                {
                    item.CheckStringForNullOrWhiteSpace();
                }

                string path = Path.Combine(arguments);

                if (checkFileExist)
                {
                    CheckExistFile(path);
                }
                if (checkDirectoryExist) 
                {
                    CheckExistDirectory(path);
                }

                return path;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ReplaceFile(string oldFile, string newFile) 
        {
            CheckExistFile(oldFile);
            File.Move(oldFile, newFile);
        }

        public static void DeleteFile(string fileName) 
        {
            CheckExistFile(fileName);
            File.Delete(fileName);
        }

        public static long GetLengthFile(string fileName) 
        {
            CheckExistFile(fileName);
            long length = new FileInfo(fileName).Length;
            return length;
        }

        /// <summary>
        /// Проверить существование файла
        /// </summary>
        /// <param name="path">Путь до файла</param>
        public static void CheckExistFile(string path) 
        {
            try
            {
                if (!File.Exists(path))
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "FileNotFoundException", currentAssembly));
                    string errorMessage = String.Format(localizationString, path);
                    throw new FileNotFoundException(errorMessage, path);
                }
            }
            catch (FileNotFoundException) 
            {
                throw;
            }
        }

        /// <summary>
        /// Проверить существование директории
        /// </summary>
        /// <param name="path">Директория</param>
        public static void CheckExistDirectory(string path) 
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    string localizationString = ManagerResources.GetString(new Resource(fileResourceName, "DirectoryNotFoundException", currentAssembly));
                    string errorMessage = String.Format(localizationString, path);
                    throw new DirectoryNotFoundException(errorMessage);
                }
            }
            catch (DirectoryNotFoundException) 
            {
                throw;
            }
        }
    }
}
