using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoodsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Goods_Info> list = ConsoleHelper.InputData();
            ConsoleHelper.PrintToConsole(list);
            int responce;
            do
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n1 - Добавить товар" +
                    "\n2 - Вывести информацию о продуктах, у которых через заданное кол-во дней закончится срок годности" +
                    "\n3 - Сохранить все данные в файл" +
                    "\n4 - Удалить данные о товаре" +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out responce);
                switch (responce)
                {
                    case 1:
                        list = list.Concat(ConsoleHelper.InputData()).ToList();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                    case 2:
                        List<Goods_Info> sortedList = SortTours(list);
                        ConsoleHelper.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = ConsoleHelper.ChooseFile(out name);
                        string message;
                        file.PrintToFile(list, name, out message);
                        Console.WriteLine(message);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);
                        list.RemoveAt(resp);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                }
            }
            while (responce != 0);
        }

        static List<Goods_Info> SortTours(List<Goods_Info> list)
        {
            Console.WriteLine("Введите кол-во дней :");
            int CountDays;
            int.TryParse(Console.ReadLine(), out CountDays);
            Console.WriteLine();
            DateTime CurrentDate = DateTime.Now;
            List<Goods_Info> sortedList = list.Where(cn => cn.ShelfLife < CurrentDate.AddDays(1 * CountDays))
                                 .OrderBy(item => item.ShelfLife)
                                 .ToList();
            return sortedList;
        }
    }
}
