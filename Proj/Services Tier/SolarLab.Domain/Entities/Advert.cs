using SolarLab.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLab.Domain
{
    /// <summary>
    /// Объявление
    /// </summary>
    public class Advert : EntityBase
    {
    
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Список комментариев к объявлению
        /// </summary>
        public List<AdvertComment> AdvertComments { get; set; }
    }
}
