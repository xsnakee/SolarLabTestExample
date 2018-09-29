using SolarLab.Domain.Entities.Base;

namespace SolarLab.Domain
{
    /// <summary>
    /// Комментарий к объявлению
    /// </summary>
    public class AdvertComment: EntityBase
    {

        /// <summary>
        /// Текст комментария к объявлению
        /// </summary>
        public string Text { get; set; }

    }
}
