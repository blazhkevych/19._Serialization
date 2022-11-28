using System.Text;

namespace task;

// IEnumerable предоставляет перечислитель, который поддерживает простой перебор элементов необобщенной коллекции.
[Serializable]
public class AcademyGroup : ICloneable
{
    // Ссылка на коллекцию студентов (ArrayList).
    public List<Student> _Group;

    // Конструктор по умолчанию.
    public AcademyGroup()
    {
        _Group = new List<Student>();
    }

    // Конструктор с параметром.
    public AcademyGroup(List<Student> group)
    {
        _Group = group;
    }

    public object Clone()
    {
        return new AcademyGroup(_Group);
    }

    // Метод Add для добавления студентов в группу.
    public void Add(int amountOfStudentsToAdd)
    {
        for (var i = 0; i < amountOfStudentsToAdd; i++)
        {
            Console.WriteLine("Введите данные о студенте №{0}:", i + 1);
            var student = new Student();
            student.Input();
            _Group.Add(student);
        }
    }

    // Метод Remove для удаления студента из группы (критерий удаления – фамилия).
    public void Remove()
    {
        Console.Clear();
        if (_Group.Count == 0)
        {
            Console.WriteLine("В группе нету студентов!");
        }
        else
        {
            PrintGroup();
            Console.WriteLine();
            Console.WriteLine("Введите № студента для удаления:");
            var studentNumberToRemove = -1;
            try
            {
                studentNumberToRemove = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            _Group.RemoveAt(studentNumberToRemove);
            Console.WriteLine();
            Console.WriteLine("Студенти удален !");
        }
    }

    // Метод Edit для редактирования сведений о студенте (критерий – фамилия студента).
    public void Edit()
    {
        Console.Clear();
        if (_Group.Count == 0)
        {
            Console.WriteLine("В группе нету студентов!");
        }
        else
        {
            PrintGroupHeader();
            for (var index = 0; index < _Group.Count; index++)
            {
                Console.Write($"{index,5}" + _Group[index]);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Введите № студента для редактирования:");
            int studentNumberToEdit;
            try
            {
                studentNumberToEdit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            try
            {
                Console.WriteLine("\nЗаполните новые данные о студенте.");

                Console.WriteLine();
                Console.Write("Имя: ");
                _Group[studentNumberToEdit].Name = Convert.ToString(Console.ReadLine()) ?? "null";

                Console.WriteLine();
                Console.Write("Фамилия: ");
                _Group[studentNumberToEdit].Surname = Convert.ToString(Console.ReadLine()) ?? "null";

                Console.WriteLine();
                Console.Write("Возраст: ");
                _Group[studentNumberToEdit].Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Телефон: ");
                _Group[studentNumberToEdit].Phone = Convert.ToString(Console.ReadLine()) ?? "null";

                Console.WriteLine();
                Console.Write("Средний балл: ");
                _Group[studentNumberToEdit].Average = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Номер группы: ");
                _Group[studentNumberToEdit].NumberOfGroup = Convert.ToString(Console.ReadLine()) ?? "null";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    // Печать хедера группы.
    private void PrintGroupHeader()
    {
        Console.Write(
            $"{" № ",6}{"Имя",19}{"Фамилия",20}{"Возраст",9}{"Телефон",20}{"Средний балл",14}{"Номер группы",14}");
        Console.WriteLine();
    }

    // Печать группы.
    public void PrintGroup()
    {
        Console.Clear();
        if (_Group.Count == 0)
        {
            Console.WriteLine("В группе нету студентов!");
        }
        else
        {
            PrintGroupHeader();
            for (var index = 0; index < _Group.Count; index++)
            {
                Console.Write($"{index,5}" + _Group[index]);
                Console.WriteLine();
            }
        }
    }

    // Метод Sort для сортировки по заданному критерию.
    public void Sort()
    {
        Console.Clear();
        if (_Group.Count == 0)
        {
            Console.WriteLine("В группе нету студентов!");
        }
        else
        {
            Console.WriteLine("Выберите критерий сортировки:");
            Console.WriteLine("1. Имя.");
            Console.WriteLine("2. Фамилия.");
            Console.WriteLine("3. Возраст");
            Console.WriteLine("4. Телефон");
            Console.WriteLine("5. Средний балл");
            Console.WriteLine("6. Группа");
            var sortCriterion = -1;
            do
            {
                try
                {
                    sortCriterion = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine();
                    Console.WriteLine("Попробуйте еще раз !");
                }
            } while (sortCriterion < 0);

            switch (sortCriterion)
            {
                case 1:
                    _Group.Sort(new Student.SortByName());
                    break;
                case 2:
                    _Group.Sort(new Student.SortBySurname());
                    break;
                case 3:
                    _Group.Sort(new Student.SortByAge());
                    break;
                case 4:
                    _Group.Sort(new Student.SortByPhone());
                    break;
                case 5:
                    _Group.Sort(new Student.SortByAverage());
                    break;
                case 6:
                    _Group.Sort(new Student.SortByNumberOfGroup());
                    break;
                default:
                    Console.WriteLine("Неверный критерий сортировки!");
                    break;
            }
        }
    }

    // Метод Save для сохранения данных в файл.
    public void Save()
    {
        var sw = new StreamWriter("Group of students.txt", false);
        foreach (var t in _Group)
        {
            var (name, surname, age, phone, average, numberOfGroup) = t;

            try
            {
                sw.WriteLine(name);
                sw.WriteLine(surname);
                sw.WriteLine(age);
                sw.WriteLine(phone);
                sw.WriteLine(average);
                sw.WriteLine(numberOfGroup);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        sw.Close();
    }

    // Метод Load для загрузки данных из файла.
    public void Load()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader("Group of students.txt", Encoding.Default);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception);
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        string name;
        try
        {
            while ((name = sr.ReadLine()) != null)
            {
                var st = new Student(name, sr.ReadLine(), Convert.ToInt32(sr.ReadLine()),
                    sr.ReadLine(), Convert.ToDouble(sr.ReadLine()), sr.ReadLine());
                _Group.Add(st);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        sr?.Close();
    }

    // Метод Search для поиска по всем полям Студента.
    public void Search()
    {
        Console.Clear();
        if (_Group.Count == 0)
        {
            Console.WriteLine("В группе нету студентов!");
        }
        else
        {
            Console.WriteLine("Введите строку для поиска:");
            var searchStr = "";
            try
            {
                searchStr = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            var firstMatch = false;
            var coincidence = 0; // Количество совпадений при поиске.
            for (var index = 0; index < _Group.Count; index++)
                if (_Group[index].ToString().Contains(searchStr))
                {
                    if (!firstMatch)
                        PrintGroupHeader();
                    firstMatch = true;
                    coincidence++;
                    Console.Write($"{index,5}" + _Group[index]);
                    Console.WriteLine();
                }

            if (coincidence == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Совпадений не найдено.");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Поиск завершен.");
            Console.WriteLine();
        }
    }

    // Метод генерации студентов в группу.
    public void Generate()
    {
        Console.Clear();

        for (var index = 0; index < 10; index++)
        {
            var student = new Student();
            student.Generate();
            _Group.Add(student);
        }

        Console.WriteLine("Студенты успешно сгенерированы!");
    }
}