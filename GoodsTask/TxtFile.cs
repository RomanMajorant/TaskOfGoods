using System;//область имен с системными базовыми классами
using System.Collections.Generic;//Коллекции и все такое
using System.IO;//для записи и чтения файлов, ввода и вывода данных


namespace GoodsTask
{
    class TxtFile : IFileManager
    {
        //string path = @"C:\Users\makot\Desktop\GoodsTask\";//!!!
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default)) //path combine
                {
                    List<Goods_Info> list = new List<Goods_Info>();
                    while (sr.Peek() > -1)
                    {
                        string name = sr.ReadLine();
                        int Price;
                        int.TryParse(sr.ReadLine(), out Price);
                        string typegoods = sr.ReadLine();
                        int countgoods;
                        int.TryParse(sr.ReadLine(), out countgoods);
                        DateTime shelflife = DateTime.Parse(sr.ReadLine());
                        Goods_Info tmp = new Goods_Info(name, typegoods, Price, countgoods, shelflife);
                        list.Add(tmp);
                        sr.ReadLine();
                    }
                    sr.Close();
                    return list;
                }
            }
            else
            {
                throw new Exception("Такого файла не существует");
            }

        }



        public void PrintToFile(List<Goods_Info> list, string fileName, out bool FlagMessage)
        {
            //string writePath = @"C:\Users\makot\Desktop\GoodsTask\";//!!!
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
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

                FlagMessage = true;
            }
            catch
            {
                FlagMessage = false;//bool и проверка сверху (внешний)
            }
        }
    }
}
