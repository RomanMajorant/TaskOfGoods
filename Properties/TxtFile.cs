using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsTask
{
    class TxtFile : IFileManager
    {
        string path = @"C:\Users\makot\source\repos\GoodsTask\GoodsTask\";
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path + fileName, System.Text.Encoding.Default))
                {
                    List<Goods_Info> list = new List<Goods_Info>();
                    while (sr.Peek() > -1)
                    {
                        string name = sr?.ReadLine();
                        string typegoods = sr?.ReadLine();
                        int Price;
                        int.TryParse(sr?.ReadLine(), out Price);
                        sr?.ReadLine();
                        int countgoods;
                        int.TryParse(sr?.ReadLine(), out countgoods);
                        sr?.ReadLine();
                        DateTime shelflife = DateTime.Parse(sr?.ReadLine());
                        Goods_Info tmp = new Goods_Info(name, typegoods, Price, countgoods, shelflife);
                        list.Add(tmp);
                    }
                    sr.Close();
                    return list;
                }
            }

            catch
            {
                throw new Exception("Такого файла не существует");
            }

        }

        public void PrintToFile(List<Goods_Info> list, string fileName)
        {
            string writePath = @"C:\Users\makot\source\repos\GoodsTask\GoodsTask\";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath + fileName, false, System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.Name);
                        sw.WriteLine(item.Price.ToString());
                        sw.WriteLine(item.TypeGoods);
                        sw.WriteLine(item.CountGoods.ToString());
                        sw.WriteLine(item.ShelfLife.ToShortDateString().ToString());
                        sw.WriteLine();
                    }
                    sw.Close();
                }
                Console.WriteLine("Запись выполнена"); Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
