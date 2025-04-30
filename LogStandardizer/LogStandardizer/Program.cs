using System;
using System.IO;
using System.Collections.Generic;
using LogStandardizer;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== СТАНДАРТИЗАТОР ЛОГ-ФАЙЛОВ ====");

        Console.Write("Введите путь к входному файлу: ");
        string inputFile = Console.ReadLine();

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("❌ Указанный файл не найден.");
            return;
        }

        Console.Write("Введите имя выходного файла (по умолчанию output.txt): ");
        string outputFile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(outputFile)) outputFile = "output.txt";

        Console.Write("Введите имя файла для проблемных строк (по умолчанию problems.txt): ");
        string problemsFile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(problemsFile)) problemsFile = "problems.txt";

        var outputLines = new List<string>();
        var problemLines = new List<string>();

        int lineNumber = 0;

        foreach (var line in File.ReadLines(inputFile))
        {
            lineNumber++;
            if (LogParser.TryParse(line, out var entry))
            {
                outputLines.Add(entry.ToString());
            }
            else
            {
                // Можно сохранить с номером строки, чтобы потом было проще найти
                problemLines.Add($"[{lineNumber}] {line}");
            }
        }

        File.WriteAllLines(outputFile, outputLines);
        File.WriteAllLines(problemsFile, problemLines);

        Console.WriteLine("\n✅ Обработка завершена.");
        Console.WriteLine($"Успешных записей: {outputLines.Count}");
        Console.WriteLine($"Проблемных записей: {problemLines.Count}");
        Console.WriteLine($"\n✔ Результат сохранён в файл: {outputFile}");
        Console.WriteLine($"⚠ Проблемные строки сохранены в: {problemsFile}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
