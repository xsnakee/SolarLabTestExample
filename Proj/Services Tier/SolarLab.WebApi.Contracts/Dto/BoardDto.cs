using System;
using System.Collections.Generic;
using SolarLab.WebApi.Contracts.Dto;
using System.Text;

namespace SolarLab.WebApi.Contracts.Dto
{
    public class BoardDto
    { /// <summary>
      /// Идентификатор доски объявлений
      /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название доски объявлений
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список объявлений на доске
        /// </summary>
        public List<AdvertDto> Adverts { get; set; }
    }
}
