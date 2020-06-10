using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsTask
{
    public class ConsoleHelper
    {
        public static void PrintToConsole(List<Goods_Info> list) //Печать листа 
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", i));
                Console.WriteLine(item.ToString());
                i++;
            }
            Console.WriteLine(String.Format("Количество товаров : {0}", i));
            Console.ReadLine();
            Console.WriteLine();
        }

        public static List<Goods_Info> InputData() // Выбор источника ввода и ввод данных
        {
            Console.WriteLine("Выберите источник для ввода информации. 1 - консоль, 2 - файл");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(name);
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        public static List<Goods_Info> InputDataFromConsole() //Ввод данных из консоли
        {
            int response;
            List<Goods_Info> list = new List<Goods_Info>();
            do
            {
                Console.WriteLine("Вводите информацию о товарах");
                Console.WriteLine();
                SetTour(list);
                Console.WriteLine("Если хотите добавить еще один товар, нажмите любую клавишу, а для отмены ввода нажмите 0");
                int.TryParse(Console.ReadLine(), out response);
            }
            while (response != 0);
            return list;
        }

        public static void SetTour(List<Goods_Info> list) //Создание объекта Tour_Info
        {
            Console.WriteLine("Введите название");
            string name = Console.ReadLine();
            Console.WriteLine("Введите тип товара");
            string typegoods = Console.ReadLine();
            Console.WriteLine("Введите  цену");
            int price;
            int.TryParse(Console.ReadLine(), out price);
            int countgoods;
            Console.WriteLine("Введите  кол-во товара");
            int.TryParse(Console.ReadLine(), out countgoods);
            Console.WriteLine("Введите срок годности");
            DateTime shelflife = DateTime.Parse(Console.ReadLine());
            Goods_Info tmp = new Goods_Info(name, typegoods, price, countgoods, shelflife);
            list.Add(tmp);
        }


        public static IFileManager ChooseFile(out string fName) //выбор типа файла для вывода информации
        {
            Console.WriteLine("Введите имя файла с его разрешением: ");
            string responce = Console.ReadLine();
            fName = responce;
            return FileFactory.GetFile(Path.GetExtension(responce));
        }
    }
}
