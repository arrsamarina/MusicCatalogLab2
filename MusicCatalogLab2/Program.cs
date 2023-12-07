using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MusicCatalogLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicCatalog catalog = new MusicCatalog();


            Console.WriteLine("Добро пожаловать в музыкальный каталог!");
            Console.WriteLine("Для вывода возможных команд введите 1");

            while (true)
            {
                Console.Write("Введите номер команды: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("1. Показать доступные команды:");
                        Console.WriteLine("2. Поиск композиции");
                        Console.WriteLine("3. Вывод информации о композициях");
                        Console.WriteLine("4. Добавление композиции");
                        Console.WriteLine("5. Удаление композиции");
                        Console.WriteLine("6. Выйти из программы");
                        break;

                    case "2":
                        Console.Write("Введите критерий поиска (название или исполнитель): ");
                        string searchCriteria = Console.ReadLine();
                        var searchResults = catalog.Search(song =>
                            song.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
                            song.Author.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase)); //поиск, нечувствительный к регистру

                        Console.WriteLine("Результаты поиска:");
                        foreach (var result in searchResults)
                        {
                            Console.WriteLine($"{result.Author} - {result.Title}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Информация о композициях в каталоге:");
                        foreach (var song in catalog.Songs)
                        {
                            Console.WriteLine($"{song.Author} - {song.Title}");
                        }
                        break;

                    case "4":
                        Song newSong = new Song();
                        Console.Write("Введите название композиции: ");
                        newSong.Title = Console.ReadLine();
                        Console.Write("Введите исполнителя: ");
                        newSong.Author = Console.ReadLine();
                        Console.Write("Введите название альбома: ");
                        newSong.AlbumName = Console.ReadLine();
                        catalog.Add(newSong);
                        Console.WriteLine("Композиция успешно добавлена в каталог!");
                        break;

                    case "5":
                        Console.Write("Введите название композиции для удаления: ");
                        string songToDelete = Console.ReadLine();
                        var songToRemove = catalog.Search(song => song.Title.Equals(songToDelete, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                        if (songToRemove != null)
                        {
                            catalog.Remove(songToRemove);
                            Console.WriteLine("Композиция успешно удалена из каталога!");
                        }
                        else
                        {
                            Console.WriteLine("Композиция не найдена в каталоге.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Некорректная команда. Пожалуйста, введите корректный номер команды.");
                        break;
                }
            }
        }
    }
}
