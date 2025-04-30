using System;
using StringCompression;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 – Сжать строку");
            Console.WriteLine("2 – Распаковать строку");
            Console.WriteLine("0 – Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите строку для сжатия: ");
                    string inputToCompress = Console.ReadLine();
                    string compressed = StringCompressor.Compress(inputToCompress);
                    Console.WriteLine($"Сжатая строка: {compressed}");
                    break;

                case "2":
                    Console.Write("Введите строку для распаковки: ");
                    string inputToDecompress = Console.ReadLine();
                    string decompressed = StringCompressor.Decompress(inputToDecompress);
                    Console.WriteLine($"Распакованная строка: {decompressed}");
                    break;

                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                    break;
            }
        }
    }
}
