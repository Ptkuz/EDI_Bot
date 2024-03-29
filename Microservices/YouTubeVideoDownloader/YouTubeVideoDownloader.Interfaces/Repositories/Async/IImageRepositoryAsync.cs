﻿using Gurrex.Common.Interfaces.Repositories;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Repositories.Async
{
    /// <summary>
    /// Асинхронный репозиторий работы с <see cref="IImage"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IImage"/></typeparam>
    public interface IImageRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : class, IImage, new()
    {

    }
}
