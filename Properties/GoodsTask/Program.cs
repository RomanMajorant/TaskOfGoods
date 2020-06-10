using System;//область имен с системными базовыми классами
using System.Collections.Generic;//Коллекции и все такое
using System.Linq;//Работа с источниками данных (в том числе массивы и т.п.)



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
                Console.WriteLine();
                if (!(int.TryParse(Console.ReadLine(), out responce))) {
                    Console.WriteLine("error");
                    return;
                }//if tryparse
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
                        bool FlagMessage;
                        file.PrintToFile(list, name, out FlagMessage);
                        Console.WriteLine(FlagMessage ? "Запись успешно выполнена" : "Запись не выполнена");
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Введите номер элемента, который нужно удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);//!!!
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
            Console.WriteLine("Введите кол-во дней:");
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
