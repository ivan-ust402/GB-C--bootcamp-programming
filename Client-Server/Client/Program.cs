// Пространство имен создается для того, чтобы данные имена были видны во всем проекте(одни и те же переменные мы можем использовать в разных файлах)
// В пространстве может быть несколько классов
namespace Client
{
    class Program 
    {
        // Начало выполнения программы
        static void Main(string[] args)
        {
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient();
        }

    }
}

