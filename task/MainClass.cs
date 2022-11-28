namespace task;

// Класс MainClass, реализующий пользовательский интерфейс приложения, и демонстрирующий работу с классом AcademyGroup.
internal class MainClass
{
    // Главное меню.
    public void MainMenu(ref AcademyGroup ag)
    {
        var choice = "";
        do
        {
            Console.Clear();
            Console.WriteLine(@"1. Добавление студентов в группу.
2. Удаление студента из группы.
3. Редактирование данных студента.
4. Печать академической группы.
5. Сортировка студентов по критерию.
6. Поиск студента по заданному критерию.
7. Сгенерировать 10 студентов.
8. Выход из программы.");
            Console.WriteLine();
            Console.WriteLine("Я выбираю: ");

            try
            {
                choice = Convert.ToString(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            switch (choice)
            {
                case "1": // 1. Добавление студентов в группу.
                    Console.WriteLine("Введите количество студентов для добавления:");
                    var amountOfStudentsToAdd = -1;
                    do
                    {
                        try
                        {
                            amountOfStudentsToAdd = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine();
                            Console.WriteLine("Попробуйте еще раз !");
                        }
                    } while (amountOfStudentsToAdd < 0);

                    ag.Add(amountOfStudentsToAdd);
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "2": // 2. Удаление студента из группы.
                    ag.Remove();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "3": // 3. Редактирование данных студента.
                    ag.Edit();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "4": // 4. Печать академической группы.
                    ag.PrintGroup();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "5": // 5. Сортировка студентов по критерию.
                    ag.Sort();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "6": // 6. Поиск студента по заданному критерию.
                    ag.Search();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "7": // 7. Сгенерировать 10 студентов.
                    ag.Generate();
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadLine();
                    break;
                case "8": // 8. Выход из программы.
                    ag.Save();
                    Environment.Exit(0);
                    break;
            }

            MainMenu(ref ag);
        } while ((choice != "1") | (choice != "2") | (choice != "3") | (choice != "4") | (choice != "5") |
                 (choice != "6") | (choice != "7"));
    }
}