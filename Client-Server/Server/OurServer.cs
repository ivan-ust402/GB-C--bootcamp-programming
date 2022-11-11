using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        // Для принятия клиентов
        TcpListener server;

        // Как только создается сервер, мы создаем наш сервер и мы нашему tcpListener даем адрес
        public OurServer()
        {
            // слушаем
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            // запускаем
            server.Start();

            // Ловим клиентов, держим подключение новых клиентов
            LoopClients();
        }

        void LoopClients()
        {   
            // Бесконечно принимаем потоки
            while (true)
            {   
                // Как только на сервер прилетает какой-то клиент, у нас сразу создается клиент, который мы будем обрабатывать на сервере
                TcpClient client = server.AcceptTcpClient();

                // Делаем обработку нескольких клиентов при помощи Thread-s(поток исполнения)

                // Кладем каждого клиента в свой Thread
                Thread thread = new Thread(() => HandleClient(client));
                // Поток сразу запускаем
                thread.Start();
            }
        }

        // Функция, которая держит отдельно клиент. Разрывов не должно быть как с клиента, так и с сервера
        void HandleClient(TcpClient client) {
            // Создаем поток, получаем сообщение от клиента
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            // Бесконечно держим клиента
            while (true)
            {
                string message = sReader.ReadLine();
                Console.WriteLine($"Клиент написал - {message}");
            }
        }
    }
}