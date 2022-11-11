// using - нужны для подключения встроенных библиотек C# для работы TCP в данном случае (протокол обмена клиент - сервер)
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        // Переменная для работы с TCP (по сути наш клиент)
        private TcpClient client;
        // Переменная для записи на сервер (поток для отправки данных с клиента на сервер)
        private StreamWriter sWriter;

        // ipAdress - адрес клиента или сервера в сети
        // Для нашей работы будем использовать адрес 127.0.0.1 - запрос на наш же компьютер (запрос самому себе - Local Host)
        // portNum - аналогия: гавань(127.0.0.1) нам нужно принять корабль то место в гавани, куда встанет корабль и называется портом, т.е. у одного ip адреса может быть множество портов. Для наших целей используем порт 5555(выбирать следует с позиции: лишь бы этот порт не был занят другой программой). Единственное правило, чтобы и на клиенте и на сервере был один порт. На клиенте указание порта является указанием того порта где нас ждут, чтобы избежать ошибки.

        // Получить ответ от сервера
        private StreamReader sReader;
        public OurClient() {
            client = new TcpClient("127.0.0.1", 5555); // создали клиента
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            HandleComunication(); // держим клиента
        }

            // Для постоянного подключения
        void HandleComunication()
        {
            while (true)
            {
                Console.Write("> ");
                string? message = Console.ReadLine();
                sWriter.WriteLine(message); // строка подготовлена к отправке
                sWriter.Flush(); // Отправить сообщение немедленно, еще очищает буфер

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Ответ сервера -> {answerServer}");
            }
        }
    }
}