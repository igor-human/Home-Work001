using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем словарь, где ключ - украинское слово, а значение - кортеж с русским и английским переводами
        var dictionary = new Dictionary<string, (string Russian, string English)>
        {
            { "кіт", ("кот", "cat") },
            { "собака", ("собака", "dog") },
            { "будинок", ("дом", "house") }
        };

        // Создаем словарь для поиска по русскому переводу
        var russianToUkrainian = new Dictionary<string, string>();
        // Создаем словарь для поиска по английскому переводу
        var englishToUkrainian = new Dictionary<string, string>();

        // Заполняем дополнительные словари
        foreach (var entry in dictionary)
        {
            // Добавляем в словарь русско-украинских переводов
            russianToUkrainian[entry.Value.Russian] = entry.Key;
            // Добавляем в словарь англо-украинских переводов
            englishToUkrainian[entry.Value.English] = entry.Key;
        }

        // Пример поиска и вывода значений по украинскому слову
        string ukrainianWord = "кіт";
        if (dictionary.TryGetValue(ukrainianWord, out var translations))
        {
            Console.WriteLine($"Украинское слово: {ukrainianWord}");
            Console.WriteLine($"Русский перевод: {translations.Russian}");
            Console.WriteLine($"Английский перевод: {translations.English}");
        }
        else
        {
            Console.WriteLine($"Слово '{ukrainianWord}' не найдено в словаре.");
        }

        // Пример поиска по русскому переводу
        string russianWord = "кот";
        if (russianToUkrainian.TryGetValue(russianWord, out var ukrainianFromRussian))
        {
            Console.WriteLine($"Русское слово: {russianWord}");
            Console.WriteLine($"Украинский перевод: {ukrainianFromRussian}");
        }
        else
        {
            Console.WriteLine($"Слово '{russianWord}' не найдено в словаре.");
        }

        // Пример поиска по английскому переводу
        string englishWord = "cat";
        if (englishToUkrainian.TryGetValue(englishWord, out var ukrainianFromEnglish))
        {
            Console.WriteLine($"Английское слово: {englishWord}");
            Console.WriteLine($"Украинский перевод: {ukrainianFromEnglish}");
        }
        else
        {
            Console.WriteLine($"Слово '{englishWord}' не найдено в словаре.");
        }
    }
}

