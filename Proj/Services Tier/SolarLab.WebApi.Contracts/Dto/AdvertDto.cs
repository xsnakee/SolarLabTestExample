using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLab.WebApi.Contracts.Dto
{
    public class AdvertDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Список комментариев к объявлению
        /// </summary>
        public List<AdvertCommentDto> AdvertComments { get; set; }
    }
}
