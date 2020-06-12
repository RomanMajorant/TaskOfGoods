using System;//область имен с системными базовыми классами
using System.Collections.Generic;//Коллекции и все такое
using System.Linq;//Работа с источниками данных (в том числе массивы и т.п.)



namespace GoodsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int responce;
            Console.WriteLine("Выберите источник для ввода информации: 1 - консоль, 2 - файл");
            if (int.TryParse(Console.ReadLine(), out responce))
            {
                List<Goods_Info> list = ConsoleHelper.InputData(responce);
                ConsoleHelper.PrintToConsole(list);
                //int responce;
                do
                {
                    Console.WriteLine("Что вы хотите сделать?" +
                        "\n1 - Добавить товар" +
                        "\n2 - Вывести информацию о продуктах, у которых через заданное кол-во дней закончится срок годности" +
                        "\n3 - Сохранить все данные в файл" +
                        "\n4 - Удалить данные о товаре" +
                        "\n0 - Завершение работы");
                    Console.WriteLine();
                    if (!(int.TryParse(Console.ReadLine(), out responce)))
                    {
                        Console.WriteLine("Error, убедитесь, что вводите цифры...");
                        Console.ReadLine();
                        return;
                    }
                    switch (responce)
                    {
                        case 1:
                            int response;
                            Console.WriteLine("Выберите источник для ввода информации: 1 - консоль, 2 - файл");
                            if ((int.TryParse(Console.ReadLine(), out response)))
                            {
                                list = list.Concat(ConsoleHelper.InputData(response)).ToList();
                                ConsoleHelper.PrintToConsole(list);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка при вводе");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Введите кол-во дней:");
                            int CountDays;
                            if (!(int.TryParse(Console.ReadLine(), out CountDays)))
                            {
                                Console.WriteLine("Ошибка ввода!");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine();
                            List<Goods_Info> sortedList = SortTours(list, CountDays);
                            ConsoleHelper.PrintToConsole(sortedList);
                            break;
                        case 3:
                            string name;
                            IFileManager file = ConsoleHelper.ChooseFile(out name);
                            Console.WriteLine(file.PrintToFile(list, name) ? "Запись успешно выполнена" : "Запись не выполнена");//done
                            Console.WriteLine();
                            break;
                        case 4:
                            Console.WriteLine();
                            Console.WriteLine("Введите номер элемента, который нужно удалить, начиная с 0");
                            int resp;
                            if (int.TryParse(Console.ReadLine(), out resp))
                            {
                                list.RemoveAt(resp);
                                Console.WriteLine("Удаление завершено");
                                Console.ReadLine();
                                ConsoleHelper.PrintToConsole(list);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка при вводе");
                                Console.ReadLine();
                            }
                            break;
                    }
                }
                while (responce != 0);
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadLine();
                return;
            }
        }
            

        static List<Goods_Info> SortTours(List<Goods_Info> list, int countdays)
        {
            //Console.WriteLine("Введите кол-во дней:");
            //int CountDays;
            //int.TryParse(Console.ReadLine(), out CountDays);//!!!!!!ИСПРАВИТЬ ТУТ ТОЖЕ ПАРСИНГ
            //Console.WriteLine();
            DateTime CurrentDate = DateTime.Now;
            List<Goods_Info> sortedList = list.Where(cn => cn.ShelfLife < CurrentDate.AddDays(1 * countdays))
                                 .OrderBy(item => item.ShelfLife)
                                 .ToList();
            return sortedList;
        }
    }
}
