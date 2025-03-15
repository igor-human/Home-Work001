using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; } // Имя человека
    public int YearOfBirth { get; set; } // Год рождения
    public List<Person> Children { get; set; } = new List<Person>(); // Список детей (потомков)

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public override string ToString()
    {
        return $"{Name} ({YearOfBirth})"; // Вывод имени и года рождения
    }
}

class FamilyTree
{
    private Dictionary<string, Person> people = new Dictionary<string, Person>(); // Хранит всех людей в дереве

    // Метод добавления родича в дерево
    public void AddRelative(string name, int yearOfBirth, string parentName = null)
    {
        if (!people.ContainsKey(name))
        {
            var person = new Person(name, yearOfBirth);
            people[name] = person; // Добавляем нового человека

            // Если указан родитель, добавляем ребенка в список детей
            if (parentName != null && people.ContainsKey(parentName))
            {
                people[parentName].Children.Add(person);
            }
        }
        else
        {
            Console.WriteLine($"Родич {name} вже існує.");
        }
    }

    // Метод удаления родича (вместе с потомками)
    public void RemoveRelative(string name)
    {
        if (people.ContainsKey(name))
        {
            people.Remove(name); // Удаляем родича из списка

            // Удаляем его из списка детей у всех оставшихся людей
            foreach (var person in people.Values)
            {
                person.Children.RemoveAll(child => child.Name == name);
            }
        }
        else
        {
            Console.WriteLine($"Родич {name} не знайдений.");
        }
    }

    // Метод получения всех потомков определенного человека
    public void GetDescendants(string name, int level = 0)
    {
        if (people.ContainsKey(name))
        {
            foreach (var child in people[name].Children)
            {
                // Выводим имя с отступом, показывающим уровень вложенности
                Console.WriteLine(new string(' ', level * 2) + "- " + child);
                GetDescendants(child.Name, level + 1); // Рекурсивно обрабатываем потомков
            }
        }
        else
        {
            Console.WriteLine($"Родич {name} не знайдений.");
        }
    }

    // Метод поиска родичей по году рождения
    public void FindRelativesByYear(int year)
    {
        var relatives = people.Values.Where(p => p.YearOfBirth == year).ToList(); // Фильтрация по году рождения
        if (relatives.Count > 0)
        {
            Console.WriteLine($"Родичі, народжені у {year}:");
            foreach (var person in relatives)
            {
                Console.WriteLine(person);
            }
        }
        else
        {
            Console.WriteLine($"Родичів, народжених у {year}, не знайдено.");
        }
    }
}

class Program
{
    static void Main()
    {
        FamilyTree tree = new FamilyTree(); // Создаем объект семейного дерева

        // Добавляем родичей в дерево
        tree.AddRelative("Олександр", 1950);
        tree.AddRelative("Іван", 1975, "Олександр");
        tree.AddRelative("Марія", 1980, "Олександр");
        tree.AddRelative("Петро", 2000, "Іван");
        tree.AddRelative("Анна", 2005, "Іван");
        tree.AddRelative("Олег", 2010, "Марія");

        // Вывод всех потомков Олександра
        Console.WriteLine("Нащадки Олександра:");
        tree.GetDescendants("Олександр");

        // Удаление одного родича
        Console.WriteLine("\nВидаляємо Петра...");
        tree.RemoveRelative("Петро");

        // Повторный вывод потомков Олександра после удаления
        Console.WriteLine("Нащадки Олександра після видалення Петра:");
        tree.GetDescendants("Олександр");

        // Поиск людей по году рождения
        Console.WriteLine("\nПошук родичів, народжених у 2005:");
        tree.FindRelativesByYear(2005);
    }
}
