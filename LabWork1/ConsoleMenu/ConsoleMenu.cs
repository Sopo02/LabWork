using System;
using System.Collections.Generic;
using System.IO;
using IOFileLibrary;

namespace LabWork1
{
    public static class ConsoleMenu
    {
        private static readonly string path;
        private static readonly FileIO fileIO;


        static ConsoleMenu()
        {
            path = Directory.GetCurrentDirectory() + "\\DB.txt";
            fileIO = new FileIO(path);
        }


        private static Student AddStudent()
        {
            Console.Write("Ім'я: ");
            string inputName = Console.ReadLine();

            Console.Write("Прізвище: ");
            string inputSurname = Console.ReadLine();

            Console.Write("Вік: ");
            string _inputAge = Console.ReadLine();
            int inputAge = int.Parse(_inputAge);


            Console.Write("Стать: ");
            string _inputSex = Console.ReadLine();
            eSex sex = default;
            _inputSex = _inputSex.ToLower();
            if (_inputSex == eSex.Male.ToString().ToLower())
            {
                sex = eSex.Male;
            }
            else if (_inputSex == eSex.Female.ToString().ToLower())
            {
                sex = eSex.Female;
            }
            else { throw new NotImplementedException(); }


            Console.Write("Курс: ");
            string _inputCourse = Console.ReadLine();
            int inputCourse = int.Parse(_inputCourse);
            if (inputCourse < 0 || inputCourse > 6) { throw new ArgumentException("Невірні дані."); }


            Console.Write("Номер студентського квитка: ");
            string _inputTicket = Console.ReadLine();


            Console.Write("Живе в гуртожитку: ");
            string _livesInDormitory = Console.ReadLine();
            bool livesInDormitory = bool.Parse(_livesInDormitory);
         
            Console.Write("Номер паспорту: ");
            string passportNumber = Console.ReadLine();


            return new Student(inputName, inputSurname, inputAge, sex , inputCourse, _inputTicket, livesInDormitory, passportNumber);
        }
        private static Seller AddSeller()
        {
            Console.Write("Ім'я: ");
            string inputName = Console.ReadLine();
            Console.Write("Прізвище: ");
            string inputSurname = Console.ReadLine();
            Console.Write("Вік: ");
            string _inputAge = Console.ReadLine();
            int inputAge = int.Parse(_inputAge);

            Console.Write("Стать: ");
            string _inputSex = Console.ReadLine();
            eSex sex = default;
            _inputSex = _inputSex.ToLower();
            if (_inputSex == eSex.Male.ToString().ToLower())
            {
                sex = eSex.Male;
            }
            else if (_inputSex == eSex.Female.ToString().ToLower())
            {
                sex = eSex.Female;
            }
            else { throw new NotImplementedException(); }

            Console.Write("Зарплата: ");
            string _inputSalary = Console.ReadLine();
            double inputSalary = double.Parse(_inputSalary);


            return new Seller(inputName, inputSurname, inputAge, sex, inputSalary);
        }
        private static Gardener AddGardener()
        {
            Console.Write("Ім'я: ");
            string inputName = Console.ReadLine();
            Console.Write("Прізвище: ");
            string inputSurname = Console.ReadLine();
            Console.Write("Вік: ");
            string _inputAge = Console.ReadLine();
            int inputAge = int.Parse(_inputAge);

            Console.Write("Стать: ");
            string _inputSex = Console.ReadLine();
            eSex sex = default;
            _inputSex = _inputSex.ToLower();
            if (_inputSex == eSex.Male.ToString().ToLower())
            {
                sex = eSex.Male;
            }
            else if (_inputSex == eSex.Female.ToString().ToLower())
            {
                sex = eSex.Female;
            }
            else { throw new NotImplementedException(); }

            Console.Write("Зарплата: ");
            string _inputSalary = Console.ReadLine();
            double inputSalary = double.Parse(_inputSalary);

            return new Gardener(inputName, inputSurname, inputAge, sex, inputSalary);
        }



        //вывод объекта
        private static void OutputObject(Student student)
        {
            Console.WriteLine("\nName: " + student.Name);
            Console.WriteLine("Surname: " + student.Surname);
            Console.WriteLine("Age: " + student.Age);
            Console.WriteLine("Sex: " + student.Sex.ToString());
            Console.WriteLine("Course: " + student.Course);
            Console.WriteLine("StudentTicket: " + student.StudentTicket);
            Console.WriteLine("LivesInDormitory: " + student.LivesInDormitory);
            Console.WriteLine("PassportNumber: " + student.PassportNumber);
        }
        private static void OutputObject(Gardener gardener)
        {
            Console.WriteLine("\nName:" + gardener.Name);
            Console.WriteLine("Surname:" + gardener.Surname);
            Console.WriteLine("Age:" + gardener.Age);
            Console.WriteLine("Sex: " + gardener.Sex.ToString());
            Console.WriteLine("Salary: " + gardener.Salary);
        }
        private static void OutputObject(Seller seller)
        {
            Console.WriteLine("\nName: " + seller.Name);
            Console.WriteLine("Surname: " + seller.Surname);
            Console.WriteLine("Age: " + seller.Age);
            Console.WriteLine("Sex: " + seller.Sex.ToString());
            Console.WriteLine("Salary: " + seller.Salary);
        }



        //расчеты студентов 3-го курса кто живет в гуртожитку
        public static bool GetSpecialData(Student student)
        {
            if (student.Course == 3)
            {
                if (student.LivesInDormitory == true)
                {
                    if (student.Sex == eSex.Male)
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        //консоль
        public static void MainMenu()
        {
            bool status = true;
            while (status)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Меню програми: ");
                    Console.WriteLine(
                        "1 - Додати особу до БД\n" +
                        "2 - Вивести дані з БД\n" +
                        "3 - Вивести дані про всіх студентів\n" +
                        "4 - Вивести дані про всіх продаваців\n" +
                        "5 - Вивести дані про всіх садівників\n" +
                        "6 - Вивести дані про студентів 3-го курсу які проживають в гуртожитку\n" +
                        "7 - Очистити БД\n" +
                        "8 - Вийти з програми");

                    Console.Write("\nОберіть бажану операцію:  ");
                    string _choice = Console.ReadLine();
                    int choice = int.Parse(_choice); Console.WriteLine("----------------------------------");

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Натисніть:" +
                                    "\n1 - Додати студента" +
                                    "\n2 - Додати продавця" +
                                    "\n3 - Додати садівника");

                                Console.Write("\nОберіть бажану операцію:  ");
                                string _inputChoice = Console.ReadLine();
                            
                                switch (_inputChoice)
                                {
                                    case "1":
                                        var student = AddStudent();
                                        Parser.AddObject(student);
                                        break;
                                    case "2":
                                        var seller = AddSeller();
                                        Parser.AddObject(seller);
                                        break;
                                    case "3":
                                        var mountaineer = AddGardener();
                                        Parser.AddObject(mountaineer);
                                        break;
                                    default:
                                        throw new Exception("Некоректне введення даних");
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine(fileIO.ReadAllFile());
                                break;
                            }
                        case 3:
                            {
                                foreach (var item in Parser.GetAllStudent())
                                {
                                    OutputObject(item);
                                }
                                break;
                            }
                        case 4:
                            {
                                foreach (var item in Parser.GetAllSeller())
                                {
                                    OutputObject(item);
                                }
                                break;
                            }
                        case 5:
                            {
                                foreach (var item in Parser.GetAllGardener())
                                {
                                    OutputObject(item);
                                }
                                break;
                            }
                        case 6:
                            {
                                var selectedStudent = Parser.GetRightStudents(Parser.GetAllStudent(), GetSpecialData);
                                foreach (var item in selectedStudent)
                                {
                                    OutputObject(item);
                                }
                                break;
                            }
                        case 7:
                            {
                                Parser.DeleteAllData();
                                break;
                            }
                        case 8:
                            {
                                status = false;
                                break;
                            }
                        default:
                            throw new Exception("Некоректне введення даних");
                    }

                    Console.WriteLine("Для продовження нажміть будь яку клавішу");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nException {e.Message}");
                    Console.WriteLine("************************************************");
                    Console.WriteLine("Для продовження нажміть будь яку клавішу");
                    Console.ReadKey();
                }
            }

        }
    }
}
