using SolarLab.Domain;
using SolarLab.WebApi.Contracts.Dto;
using System.Collections.Generic;

namespace SolarLab.AppServices
{
    public interface IAdvertService
    {
        /// <summary>
        /// Получает все комментарии к объвлению
        /// </summary>
        /// <param name="advertId">Идентификатор объявления</param>
        /// <returns>Список комментариев</returns>
        List<AdvertCommentDto> GetAllAdvertComments(int advertId);
        
        /// <summary>
        /// Получает объявление по идентификатору
        /// </summary>
        /// <param name="advertId">Идентификтаор объявления</param>
        /// <returns>Объявление</returns>
        AdvertDto GetAdvertById(int advertId);
    }
}