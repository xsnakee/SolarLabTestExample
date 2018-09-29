using System;
using System.Collections.Generic;
using SolarLab.Domain.Entities.Base;

namespace SolarLab.Domain
{
    /// <summary>
    /// Доска объявлений
    /// </summary>
    public class Board : EntityBase
    {
        /// <summary>
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
        public List<Advert> Adverts { get; set; }
    }
}
