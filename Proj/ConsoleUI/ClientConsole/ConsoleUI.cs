using SolarLab.Domain;
using SolarLab.WebApi.Contracts.Dto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientConsole
{

    public class ConsoleUI
    {
        LineParser _lineParser = new LineParser();
        public async void Start()
        {
         

            int? id = null;
            while (true)
            {
                ConsoleSettings(ConsoleColor.Blue, ConsoleColor.White);
                Console.WriteLine();
                Console.WriteLine("Введите идентификатор объявления или q для выхода");
                var line = Console.ReadLine();

                try
                {
                    ConsoleSettings(ConsoleColor.White, ConsoleColor.Red);
                    id = _lineParser.AnalizeLine(line);
                    if (id.HasValue)
                    {
                        AdvertDto adv = GetResultFromServcie(id.Value).Result;
                        PrintResult(adv);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public async void Run()
        {


            int? id = null;
            while (true)
            {
                ConsoleSettings(ConsoleColor.Blue, ConsoleColor.White);
                Console.WriteLine();
                Console.WriteLine("Введите идентификатор раздела или q для выхода");
                var line = Console.ReadLine();

                try
                {
                    ConsoleSettings(ConsoleColor.White, ConsoleColor.Red);
                    id = _lineParser.AnalizeLine(line);
                    if (id.HasValue)
                    {
                        BoardDto board = GetBoardsFromServce(id.Value).Result;
                        PrintResult(board);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }


        private static void ConsoleSettings(ConsoleColor back, ConsoleColor foreground)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = foreground;
        }

        private void PrintResult(AdvertDto adv)
        {
            if (adv == null)
            {
                Console.WriteLine("##########################################");
                Console.WriteLine("################  Пусто  #################");
                Console.WriteLine("##########################################");

            }
            else
            {
                Console.WriteLine("##########################################");
                Console.WriteLine("################Объявление################");
                Console.WriteLine($"Id : {adv.Id}, Text : {adv.Text}");
                Console.WriteLine("################Комментарии###############");

                if (adv.AdvertComments != null && adv.AdvertComments.Count > 0)
                {
                    int i = 0;
                    foreach (var comment in adv.AdvertComments)
                    {
                        Console.WriteLine($"№{++i}. Id : {comment.Id}, Text : {comment.Text}");
                    }
                }

                Console.WriteLine("##########################################");
            }

        }

        private void PrintResult(BoardDto board)
        {
            if (board == null)
            {
                Console.WriteLine("##########################################");
                Console.WriteLine("################  Пусто  #################");
                Console.WriteLine("##########################################");

            }
            else
            {
                Console.WriteLine("##########################################");
                Console.WriteLine("################Раздел################");
                Console.WriteLine($"Id : {board.Id}, Name : {board.Name}");
                Console.WriteLine("################Объявления###############");
                if (board.Adverts != null && board.Adverts.Count > 0)
                {
                    foreach (var adv in board.Adverts)
                    {
                        Console.WriteLine("##########################################");
                        Console.WriteLine("################Объявление################");
                        Console.WriteLine($"Id : {adv.Id}, Text : {adv.Text}");
                        Console.WriteLine("################Комментарии###############");
                        if (adv.AdvertComments != null && adv.AdvertComments.Count > 0)
                        {
                            int i = 0;
                            foreach (var comment in adv.AdvertComments)
                            {
                                Console.WriteLine($"№{++i}. Id : {comment.Id}, Text : {comment.Text}");
                            }
                        }
                    }
                    
                }
                

                Console.WriteLine("##########################################");
            }

        }

        private async Task<AdvertDto> GetResultFromServcie(int id)
        {
            AdvertDto result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:63405/api/adverts/{id}");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AdvertDto>();
                }
            }
            return result;
        }

        private async Task<BoardDto> GetBoardsFromServce(int id)
        {
            BoardDto result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:63405/api/boards/{id}");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<BoardDto>();
                }
            }
            return result;
        }
    }
}
