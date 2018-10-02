using SolarLab.Domain;
using SolarLab.WebApi.Contracts.Dto;
using System.Collections.Generic;
using System.Runtime;

namespace SolarLab.AppServices
{
    public interface IBoardService
    {

        /// <summary>
        /// Получает список всех объявлений в разделе
        /// </summary>
        /// <param name="boardId">Идентификатор раздела объявлений</param>
        /// <returns>List<AdvertDto></returns>
        List<AdvertDto> GetAllAdverts(int boardId);

        /// <summary>
        /// Получает объявление по идентификатору
        /// </summary>
        /// <param name="boardId">Идентификтаор объявления</param>
        /// <returns>BoardDto</returns>
        BoardDto GetBoardById(int boardId);
    }
}