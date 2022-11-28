using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace task;

internal class Program
{
    /// <summary>
    ///     В проекте «Академическая группа» реализовать сохранение и
    ///     загрузку данных, используя механизм сериализации и десериализации
    ///     соответственно. Предусмотреть несколько вариантов сериализации,
    ///     применяя различные форматы (Binary, SOAP, XML, JSON).
    /// </summary>
    private static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new("Иван", "Иванов", 20, "+380-00-000-00-00", 5.5, "0а"),
            new("Петр", "Петров", 21, "+380-00-000-00-01", 4.5, "0а"),
            new("Сидор", "Сидоров", 22, "+380-00-000-00-02", 4.4, "0а"),
            new("Андрей", "Андреев", 23, "+380-00-000-00-03", 4.3, "0а"),
            new("Алексей", "Алексеев", 24, "+380-00-000-00-04", 4.2, "0а")
        };

        Console.WriteLine("Исходный список студентов группы:");
        foreach (var student in students)
            Console.WriteLine(student);

        Console.WriteLine();

        char answer;
        try
        {
            do
            {
                Console.WriteLine("1. Сериализация массива объектов (BinaryFormatter).");
                Console.WriteLine("2. Десериализация массива объектов (BinaryFormatter).");
                Console.WriteLine("3. Сериализация массива объектов (SoapFormatter).");
                Console.WriteLine("4. Десериализация массива объектов (SoapFormatter).");
                Console.WriteLine("5. Сериализация массива объектов (XmlSerializer).");
                Console.WriteLine("6. Десериализация массива объектов (XmlSerializer).");
                Console.WriteLine("7. Сериализация массива объектов (DataContractJsonSerializer).");
                Console.WriteLine("8. Десериализация массива объектов (DataContractJsonSerializer).");
                Console.WriteLine("9. Выход");
                Console.Write("Выберите пункт меню: ");

                var choice = Convert.ToInt32(Console.ReadLine());

                FileStream fs;

                switch (choice)
                {
                    case 1: // 1.Сериализация массива объектов (BinaryFormatter).
                        BinaryFormatter binaryFormatter = new();
                        fs = new FileStream("studentsBinary.dat", FileMode.OpenOrCreate);
                        binaryFormatter.Serialize(fs, students);
                        fs.Close();
                        Console.WriteLine("Сериализация прошла успешно");
                        break;
                    case 2: // 2. Десериализация массива объектов (BinaryFormatter).
                        binaryFormatter = new BinaryFormatter();
                        fs = new FileStream("studentsBinary.dat", FileMode.OpenOrCreate);
                        students = (List<Student>)binaryFormatter.Deserialize(fs);
                        fs.Close();
                        foreach (var student in students)
                            Console.WriteLine(student);
                        Console.WriteLine("Десериализация прошла успешно");
                        break;
                    case 3: // 3. Сериализация массива объектов (SoapFormatter).
                        SoapFormatter soapFormatter = new();
                        fs = new FileStream("studentsSoap.dat", FileMode.OpenOrCreate);
                        soapFormatter.Serialize(fs, students);
                        fs.Close();
                        Console.WriteLine("Сериализация прошла успешно");
                        break;
                    case 4: // 4. Десериализация массива объектов (SoapFormatter).
                        soapFormatter = new SoapFormatter();
                        fs = new FileStream("studentsSoap.dat", FileMode.OpenOrCreate);
                        students = (List<Student>)soapFormatter.Deserialize(fs);
                        fs.Close();
                        foreach (var student in students)
                            Console.WriteLine(student);
                        Console.WriteLine("Десериализация прошла успешно");
                        break;
                    case 5: // 5. Сериализация массива объектов (XmlSerializer).
                        XmlSerializer xmlSerializer = new(typeof(List<Student>));
                        fs = new FileStream("studentsXml.xml", FileMode.OpenOrCreate);
                        xmlSerializer.Serialize(fs, students);
                        fs.Close();
                        Console.WriteLine("Сериализация прошла успешно");
                        break;
                    case 6: // 6. Десериализация массива объектов (XmlSerializer).
                        xmlSerializer = new XmlSerializer(typeof(List<Student>));
                        fs = new FileStream("studentsXml.xml", FileMode.OpenOrCreate);
                        students = (List<Student>)xmlSerializer.Deserialize(fs);
                        fs.Close();
                        foreach (var student in students)
                            Console.WriteLine(student);
                        Console.WriteLine("Десериализация прошла успешно");
                        break;
                    case 7: // 7. Сериализация массива объектов (DataContractJsonSerializer).
                        DataContractJsonSerializer jsonSerializer = new(typeof(List<Student>));
                        fs = new FileStream("studentsJson.json", FileMode.OpenOrCreate);
                        jsonSerializer.WriteObject(fs, students);
                        fs.Close();
                        Console.WriteLine("Сериализация прошла успешно");
                        break;
                    case 8: // 8. Десериализация массива объектов (DataContractJsonSerializer).
                        jsonSerializer = new DataContractJsonSerializer(typeof(List<Student>));
                        fs = new FileStream("studentsJson.json", FileMode.OpenOrCreate);
                        students = (List<Student>)jsonSerializer.ReadObject(fs);
                        fs.Close();
                        foreach (var student in students)
                            Console.WriteLine(student);
                        Console.WriteLine("Десериализация прошла успешно");
                        break;
                    case 9: // 9. Выход.
                        return;
                }

                Console.WriteLine("Продолжим? (y/n) ");
                answer = Convert.ToChar(Console.ReadLine());
                Console.Clear();
            } while (answer == 'y');
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}