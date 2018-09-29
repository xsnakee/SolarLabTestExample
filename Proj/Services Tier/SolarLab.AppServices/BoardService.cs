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
    public class BoardService : IBoardService
    {
        public BoardService(RepositoryBase<Board> boardRepository, RepositoryBase<Advert> advertRepository)
        {
            _boardRepository = boardRepository;
            _advertRepository = advertRepository;
        }
                /// <summary>
        /// Репозиторий по работе с объявлениями
        /// </summary>
        protected readonly RepositoryBase<Board> _boardRepository;
        protected readonly RepositoryBase<Advert> _advertRepository;
        
        /// <summary>
        /// Получает все объвления из раздела
        /// </summary>
        /// <param name="boardId">Идентификатор раздела объявлений</param>
        /// <returns>Список объявлений</returns>
        public List<AdvertDto> GetAllAdverts(int boardId)
        {
            var board =_boardRepository.Get(boardId);
            return board.Adverts
                .Select(x => new AdvertDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    AdvertComments = x.AdvertComments
                                       .Select(z => new AdvertCommentDto
                                       {
                                           Id = z.Id,
                                           Text = z.Text
                                       })
                                       .ToList()
                })
                .ToList();
        }

        /// <summary>
        /// Получает объявления и комментарии по идентификатору
        /// </summary>
        /// <param name="boardId">Идентификтаор объявления</param>
        /// <returns>Раздел объявлений</returns>
        public BoardDto GetBoardById(int boardId)
        {
            Board board = _boardRepository.Get(boardId);
            if (board == null)
            {
                return null;
            }

            return new BoardDto
            {
                Id = board.Id,
                Name = board.Name,
                Adverts = board.Adverts
                                    .Select(x => new AdvertDto
                                    {
                                        Id = x.Id,
                                        Text = x.Text,
                                        AdvertComments = x.AdvertComments
                                        .Select(z => new AdvertCommentDto
                                        {
                                            Id = z.Id,
                                            Text = z.Text
                                        }).ToList()
                                    })
                                    .ToList()

        };
        }
    }
}
