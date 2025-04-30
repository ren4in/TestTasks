using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Параллельные читатели
        for (int i = 0; i < 5; i++)
        {
            Task.Run(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"[Reader] Count: {Server.GetCount()}");
                    Thread.Sleep(100);
                }
            });
        }

        // Писатели
        for (int i = 0; i < 2; i++)
        {
            Task.Run(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    Server.AddToCount(1);
                    Console.WriteLine("[Writer] Добавил 1 к count");
                    Thread.Sleep(150);
                }
            });
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
