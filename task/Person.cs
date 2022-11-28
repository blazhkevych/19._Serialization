using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace task;

[Serializable]
public class Person
{
    // Автоматические свойства _Name, Surname, Age, Phone.
    public string Name { get; set; }         // Имя.
    public string Surname { get; set; }      // Фамилия.
    public int Age { get; set; }             // Возраст.
    public string Phone { get; set; }        // Телефон.

    // Конструктор по умолчанию.
    protected Person()
    {
        Name = "Не задано";
        Surname = "Не задано";
        Age = 1;
        Phone = "+380-00-000-00-00";
    }

    // Конструктор с параметрами.
    protected Person(string name, string surname, int age, string phone)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Phone = phone;
    }

    // Метод вывода информации на экран.
    public override string ToString()
    {
        return $"{Name,20}{Surname,20}{Age,9}{Phone,20}";
    }

    // Ввод данных о персоне.
    internal void Input()
    {
        Console.Write("Имя: ");
        try
        {
            Name = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Name = "Не задано";
        }
        Console.Write("Фамилия: ");
        try
        {
            Surname = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Surname = "Не задано";
        }
        Console.Write("Возраст: ");
        try
        {
            Age = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Age = 1;
        }
        Console.Write("Телефон: ");
        try
        {
            Phone = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Phone = "+380-00-000-00-00";
        }
    }

    // Метод генерации данных персоны.
    internal void Generate()
    {
        Random rnd = new Random();
        Name = "Имя" + rnd.Next(1, 100);
        Surname = "Фамилия" + rnd.Next(1, 100);
        Age = rnd.Next(1, 100);
        Phone = "+380-" + rnd.Next(10, 99) + "-" + rnd.Next(100, 999) + "-" + rnd.Next(10, 99) + "-" + rnd.Next(10, 99);
    }
}