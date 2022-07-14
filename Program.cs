using Newtonsoft.Json;
using System;

/// <summary>
/// Программа поиска кинофильмов
/// </summary>
class MoviesApplicationProgram
{
    /// <summary>
    /// Выполнение с аргументами из комманлной строки
    /// </summary>
    static void Main(string[] args)
    {
        var MDB = new TheMovieDatabaseService();
        if(Environment.UserInteractive)
        {
            string input = null;
            int page = 1;
            do
            {                
                if (input != null)
                {
                    Console.WriteLine("Запрос: " + input);
                    Console.WriteLine("Ответ: \n" + JsonConvert.SerializeObject(MDB.movieSearch(input, 1).Result, Formatting.Indented));                    
                }
                Console.Write("Поиск: (Для выхода введите пустую строку) => ");
                input = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(input) == false);
        }
        else
        {
            int n = 1;
            foreach (string arg in args)
            {
                Console.WriteLine("\n\n" + n++);
                Console.WriteLine("Запрос: " + arg);
                Console.WriteLine("Ответ: \n" + JsonConvert.SerializeObject(MDB.movieSearch(arg, 1).Result));
            }
        }
        
    }
}
