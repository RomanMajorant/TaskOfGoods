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
        string path = @"C:\Users\makot\Desktop\GoodsTask\";
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
                        int Price;
                        int.TryParse(sr?.ReadLine(), out Price);
                        string typegoods = sr?.ReadLine();
                        int countgoods;
                        int.TryParse(sr?.ReadLine(), out countgoods);
                        DateTime shelflife = DateTime.Parse(sr?.ReadLine());
                        Goods_Info tmp = new Goods_Info(name, typegoods, Price, countgoods, shelflife);
                        list.Add(tmp);
                        sr?.ReadLine();
                    }
                    sr.Close();
                    return list;
                }
            }

            catch
            {
                if (!File.Exists(fileName))
                {
                    throw new Exception("Такого файла не существует");
                }
                else
                {
                    throw new Exception("Файл пустой");
                }
            }

        }

        public void PrintToFile(List<Goods_Info> list, string fileName, out string message)
        {
            string writePath = @"C:\Users\makot\Desktop\GoodsTask\";
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

                message = "Запись выполнена";
            }
            catch 
            {
                message = "Запись не выполнена";
            }
        }
    }
}
