using System;
using System.IO;

class TextEditor
{
    static void Main(string[] args)
    {
        string fileName;
        string[] fileLines;

        Console.WriteLine("Простой текстовый редактор");
        Console.WriteLine("---------------------------");

        // Запрашиваем у пользователя имя файла для открытия или создания нового файла
        Console.Write("Введите имя файла: ");
        fileName = Console.ReadLine();

        // Проверяем существует ли файл, если нет - создаем новый
        if (!File.Exists(fileName))
        {
            // Создаем новый файл и открываем его для записи
            using (StreamWriter sw = File.CreateText(fileName))
            {
                Console.WriteLine($"Файл {fileName} создан.");
            }
        }

        // Считываем содержимое файла
        fileLines = File.ReadAllLines(fileName);

        // Выводим содержимое файла на экран
        Console.WriteLine($"Содержимое файла {fileName}:");
        foreach (string line in fileLines)
        {
            Console.WriteLine(line);
        }

        // Добавляем новые строки в файл
        Console.WriteLine("Введите текст для добавления в файл (для завершения введите пустую строку):");
        using (StreamWriter sw = File.AppendText(fileName))
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                sw.WriteLine(input);
                input = Console.ReadLine();
            }
        }

        Console.WriteLine("Текст добавлен в файл.");

        // Повторно считываем содержимое файла и выводим его на экран
        fileLines = File.ReadAllLines(fileName);
        Console.WriteLine($"Обновленное содержимое файла {fileName}:");
        foreach (string line in fileLines)
        {
            Console.WriteLine(line);
        }
    }
}

