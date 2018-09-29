using SolarLab.Domain;
using SolarLab.Domain.Data.Repositories.Base;
using SolarLab.WebApi.Contracts.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SolarLab.AppServices
{
    /// <summary>
    /// Сервис работы с объвлениями 
    /// </summary>
    public class AdvertService : IAdvertService
    {
        public AdvertService(RepositoryBase<Advert> advertRepository)
        {
            _advertRepository = advertRepository;
        }
                /// <summary>
        /// Репозиторий по работе с объявлениями
        /// </summary>
        protected readonly RepositoryBase<Advert> _advertRepository;
        
        /// <summary>
        /// Получает все комментарии к объвлению
        /// </summary>
        /// <param name="advertId">Идентификатор объявления</param>
        /// <returns>Список комментариев</returns>
        public List<AdvertCommentDto> GetAllAdvertComments(int advertId)
        {
            var ad =_advertRepository.Get(advertId);
            return ad.AdvertComments
                .Select(x => new AdvertCommentDto
                {
                    Id = x.Id,
                    Text = x.Text
                })
                .ToList();
        }

        /// <summary>
        /// Получает объявление по идентификатору
        /// </summary>
        /// <param name="advertId">Идентификтаор объявления</param>
        /// <returns>Объявление</returns>
        public AdvertDto GetAdvertById(int advertId)
        {
            Advert ad = _advertRepository.Get(advertId);
            if (ad == null)
            {
                return null;
            }

            return new AdvertDto
            {
                Id = ad.Id,
                Text = ad.Text,
                AdvertComments = ad.AdvertComments
                                    .Select(x => new AdvertCommentDto
                                    {
                                        Id = x.Id,
                                        Text = x.Text
                                    })
                                    .ToList()

        };
        }
    }
}
