namespace task;

// Существует возможность «научить» класс сортироваться.
// Для этого необходимо отнаследовать класс от интерфейса IComparable.
[Serializable]
public class Student : Person, IComparable<Student>
{
    // Автоматические свойства Average, NumberOfGroup.
    public double Average { get; set; }            // Средний балл.
    public string NumberOfGroup { get; set; }      // Номер группы.

    // Конструктор по умолчанию.
    public Student() : this("Не задано", "Не задано", 0, "+380 - 00 - 000 - 00 - 00", 0.0, "Не задано") { }

    // Конструктор с параметрами.
    public Student(string name, string surname, int age, string phone, double average, string numberOfGroup)
        : base(name, surname, age, phone)
    {
        Average = average;
        NumberOfGroup = numberOfGroup;
    }

    // Деконструкторы позволяют выполнить декомпозицию объекта на отдельные части.
    public void Deconstruct(out string name, out string surname, out int age, out string phone, out double average, out string numberOfGroup)
    {
        name = Name;
        surname = Surname;
        age = Age;
        phone = Phone;
        average = Average;
        numberOfGroup = NumberOfGroup;
    }

    // Метод вывода информации на экран.
    public int CompareTo(Student? other)
    {
        return Surname.CompareTo(other.Surname);
    }

    public override string ToString()
    {
        return base.ToString() + $"{Average,14}{NumberOfGroup,14}";
    }

    // Ввод данных о студенте.
    internal void Input()
    {
        base.Input();
        Console.Write("Средний балл: ");
        try
        {
            Average = double.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Average = 0.0;
        }
        Console.Write("Номер группы: ");
        try
        {
            NumberOfGroup = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            NumberOfGroup = "Не задано";
        }
    }

    // Метод генерации данных студента.
    internal void Generate()
    {
        base.Generate();
        Average = new Random().Next(0, 100) / 10.0;
        NumberOfGroup = new Random().Next(100, 999).ToString();
    }

    // Вложенные классы, реализующие интерфейс IComparer (для сортировки по различным критериям). 
    // Сортировка по имени.
    public class SortByName : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.Name.CompareTo(obj2.Name);
        }
    }

    // Сортировка по фамилии.
    public class SortBySurname : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.Surname.CompareTo(obj2.Surname);
        }
    }

    // Сортировка по возрасту.
    public class SortByAge : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.Age.CompareTo(obj2.Age);
        }
    }

    // Сортировка по телефону.
    public class SortByPhone : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.Phone.CompareTo(obj2.Phone);
        }
    }

    // Сортировка по среднему баллу.
    public class SortByAverage : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.Average.CompareTo(obj2.Average);
        }
    }

    // Сортировка по номеру группы.
    public class SortByNumberOfGroup : IComparer<Student>
    {
        int IComparer<Student>.Compare(Student obj1, Student obj2)
        {
            return obj1.NumberOfGroup.CompareTo(obj2.NumberOfGroup);
        }
    }
}