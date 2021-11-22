using System;
using System.Collections.Generic;

using BinaryTreeProject;


namespace LabWork2
{
    public static class ConsoleMenu
    {
        private const string EXIT_WORD = "exit";
        private const string MESSAGE_STOP = "Натисніть будь яку клавішу щоб продовжити.";


        //Приватние структури данних
        private static List<SpecialString> list;
        private static SpecialString[] array;
        private static BinaryTree<SpecialString> binaryTree;


        //Статический конструктор инициализации
        static ConsoleMenu()
        {
            list = new List<SpecialString>()
            {
                new SpecialString("QJFqw_134") ,
                new SpecialString("yfr4534") ,
                new SpecialString("UI_JUYN-36345") ,
            };
            array = new SpecialString[3] 
            {
                new SpecialString("grtgrer") ,
                new SpecialString("SPQTRY34242") ,
                new SpecialString("MUNYwrert***564545") ,
            };
            binaryTree = new BinaryTree<SpecialString>()
            {
                new SpecialString("qw134") ,
                new SpecialString("yfr4534") ,
                new SpecialString("ase544") ,
                new SpecialString("DEUBGF34534") ,
                new SpecialString("mans764") ,
            };
        }


        private static SpecialString GetAccount()
        {
            Console.WriteLine("Введіть строку : ");
            string newString = Console.ReadLine();

            return new SpecialString(newString);
        }


        #region GetInformation

        //метод виводит сообщения и потом чистит консоль и переходит в MainMenu
        private static void GetStopInfoAndGoNextMenu(bool performed, Action nextMenu)
        {
            string good = "Операція успішно виконана!";
            string bad = "Сталася помилка. Операція не виконана!";

            if (performed)
                Console.WriteLine($"{good} {MESSAGE_STOP}");
            else { Console.WriteLine($"{bad} {MESSAGE_STOP}"); }

            Console.ReadKey();
            Console.Clear();

            nextMenu.Invoke();
        }
        //Когда ведено неправильное слово
        private static void WhenWritingWrongWord()
        {
            Console.Clear();
            Console.WriteLine($"Будь-ласка ведіть правильні дані. Або наберіть {EXIT_WORD} для виходу");
        }

        #endregion


        #region SpecialMenu

        private static void ListMenu()
        {

            bool flag = true;
            while (flag)
            {
                flag = false;

                Console.WriteLine("\t\t\tВас вітає меню по роботі з List<Account>.");
                Console.WriteLine("1 - Додати об'єкт в початок.");
                Console.WriteLine("2 - Видалити об'єкт по значеню.");
                Console.WriteLine("3 - Дізнатися кількість елементів.");
                Console.WriteLine("4 - Видалити об'єкт за індексом.");
                Console.WriteLine("5 - Переглянути всі об'єкти.");
                Console.WriteLine("6 - Повністю очистити список.");

                string str = Console.ReadLine();
                str = str.ToLower();

                switch (str)
                {
                    case ("1"):
                        {
                            list.Add(GetAccount());

                            GetStopInfoAndGoNextMenu(true, ListMenu);
                            break;
                        }
                    case ("2"):
                        {
                            var encryptStr = GetAccount();

                            if (list.Remove(encryptStr))
                            {
                                GetStopInfoAndGoNextMenu(true, ListMenu);
                            }

                            GetStopInfoAndGoNextMenu(false, ListMenu);
                            break;
                        }
                    case ("3"):
                        {
                            Console.WriteLine($"Кількість елементів = {list.Count}");
                            GetStopInfoAndGoNextMenu(true, ListMenu);
                            break;
                        }
                    case ("4"):
                        {
                            Console.WriteLine("Ведіть індекс для видалення : ");
                            int index = int.Parse(Console.ReadLine());
                            if (index < 0 || index > list.Count - 1)
                                GetStopInfoAndGoNextMenu(false, ListMenu);

                            list.RemoveAt(index);

                            GetStopInfoAndGoNextMenu(true, ListMenu);
                            break;
                        }
                    case ("5"):
                        {
                            int index = 0;
                            foreach (var item in list)
                            {
                                Console.WriteLine($"#{index} =\t{item.GetInfo()}");
                                index++;
                            }

                            GetStopInfoAndGoNextMenu(true, ListMenu);
                            break;
                        }
                    case ("6"):
                        {
                            list.Clear();
                            GetStopInfoAndGoNextMenu(true, ListMenu);
                            break;
                        }
                    case EXIT_WORD:
                        {
                            Console.Clear();
                            MainMenu();
                            return;
                        }

                    default:
                        WhenWritingWrongWord();
                        flag = true;
                        break;
                }
            }
        }
        private static void ArrayMenu()
        {

            bool flag = true;
            while (flag)
            {
                flag = false;

                Console.WriteLine("\t\t\tВас вітає меню по робота з Array.");
                Console.WriteLine("1 - Додати об'єкт.");
                Console.WriteLine("2 - Видалити об'єкт.");
                Console.WriteLine("3 - Дізнатися кількість елементів.");
                Console.WriteLine("4 - Переглянути всі об'єкти.");
                Console.WriteLine("5 - Повністю очистити масив.");

                string str = Console.ReadLine();
                str = str.ToLower();

                switch (str)
                {
                    case ("1"):
                        {
                            var data = GetAccount();

                            Add(ref array, data);

                            GetStopInfoAndGoNextMenu(true, ArrayMenu);
                            break;
                        }
                    case ("2"):
                        {
                            var data = GetAccount();

                            bool res = Remove(ref array, data);

                            GetStopInfoAndGoNextMenu(res, ArrayMenu);
                            break;
                        }
                    case ("3"):
                        {
                            Console.WriteLine($"Кількість елементів = {array.Length}");
                            GetStopInfoAndGoNextMenu(true, ArrayMenu);
                            break;
                        }
                    case ("4"):
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                Console.WriteLine($"#{i} =\t{array[i].GetInfo()}");
                            }

                            GetStopInfoAndGoNextMenu(true, ArrayMenu);
                            break;
                        }
                    case ("5"):
                        {
                            array = new SpecialString[0];

                            GetStopInfoAndGoNextMenu(true, ArrayMenu);
                            break;
                        }
                    case EXIT_WORD:
                        {
                            Console.Clear();
                            MainMenu();
                            return;
                        }

                    default:
                        WhenWritingWrongWord();
                        flag = true;
                        break;
                }
            }
        }
        private static void BinaryTreeMenu()
        {

            bool flag = true;
            while (flag)
            {
                flag = false;

                Console.WriteLine("\tМеню по роботі з BinaryTree<Account>.");
                Console.WriteLine("1 - Додати об'єкт.");
                Console.WriteLine("2 - Видалити об'єкт.");
                Console.WriteLine("3 - Дізнатися кількість елементів.");
                Console.WriteLine("4 - Переглянути всі об'єкти.");
                Console.WriteLine("5 - Повністю очистити дерево.");
                Console.WriteLine("6 - Виконати операцій для всіх об'єктів в дереві.");

                string str = Console.ReadLine();
                str = str.ToLower();

                switch (str)
                {
                    case ("1"):
                        {
                            SpecialString encryption = GetAccount();
                            binaryTree.Add(encryption);

                            GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);
                            break;
                        }
                    case ("2"):
                        {
                            SpecialString encryption = GetAccount();

                            if (binaryTree.Remove(encryption))
                                GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);

                            else { GetStopInfoAndGoNextMenu(false, BinaryTreeMenu); }

                            break;
                        }
                    case ("3"):
                        {
                            Console.WriteLine($"Кількість елементів = {binaryTree.Count}");
                            GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);
                            break;
                        }
                    case ("4"):
                        {
                            int index = 0;
                            foreach (var item in binaryTree)
                            {
                                Console.WriteLine($"#{index} =\t{item.GetInfo()}");
                                index++;
                            }

                            GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);
                            break;
                        }
                    case ("5"):
                        {
                            binaryTree.Clear();

                            GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);
                            break;
                        }
                    case ("6"):
                        {
                            Console.WriteLine("\t\t\tВивід інформації");
                            int index = 0;
                            foreach (var item in binaryTree)
                            {
                                Console.WriteLine($"#{index} =\t{item.GetInfo()}");
                                index++;
                            }

                            Console.WriteLine("\n================================\n");

                            Console.WriteLine("\t\t\tДодавання підстроки OOP_LAB_2");

                            string substring = "OOP_LAB_2";
                            foreach (var item in binaryTree)
                            {
                                item.AddSubstring(substring);
                                Console.WriteLine($"#{index} =\t{item.GetInfo()}");
                                index++;
                            }

                            GetStopInfoAndGoNextMenu(true, BinaryTreeMenu);
                            break;
                        }
                    case EXIT_WORD:
                        {
                            Console.Clear();
                            MainMenu();
                            return;
                        }

                    default:
                        WhenWritingWrongWord();
                        flag = true;
                        break;
                }
            }
        }

        #endregion


        //Главний метод
        public static void MainMenu()
        {
            try
            {

                bool flag = true;
                while (flag)
                {
                    flag = false;

                    Console.WriteLine("\t\t\t\t\tВас вітає головне меню програми.");
                    Console.WriteLine("1 - Робота з List<T>.");
                    Console.WriteLine("2 - Робота з Array.");
                    Console.WriteLine("3 - Робота з моїм BinaryTree<T>.");

                    string str = Console.ReadLine();
                    str = str.ToLower();

                    switch (str)
                    {
                        case ("1"):
                            {
                                Console.Clear();
                                ListMenu();
                                break;
                            }
                        case ("2"):
                            {
                                Console.Clear();
                                ArrayMenu();
                                break;
                            }
                        case ("3"):
                            {
                                Console.Clear();
                                BinaryTreeMenu();
                                break;
                            }
                        case EXIT_WORD: { return; }

                        default:
                            WhenWritingWrongWord();
                            flag = true;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                MainMenu();
            }

        }



        #region ArrayWork

        public static void Add<T>(ref T[] array, T item)
        {
            T[] newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++) { newArray[i] = array[i]; }
            newArray[newArray.Length - 1] = item;

            array = newArray;
        }

        public static bool Remove<T>(ref T[] array, T item)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item)) { index = i; }
            }

            //проверка есть ли такой елемент или нет
            if (index < 0) { return false; }

            //создания нового масива и заполнения
            int currentPosition = 0;
            T[] newArray = new T[array.Length - 1];

            for (int i = 0; i < index; i++, currentPosition++)
            {
                newArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++, currentPosition++)
            {
                newArray[currentPosition] = array[i];
            }


            array = newArray;
            return true;
        }

        #endregion


    }
}
