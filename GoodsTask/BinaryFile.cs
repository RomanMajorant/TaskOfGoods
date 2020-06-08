using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace GoodsTask
{
    class BinaryFile : IFileManager
    {
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            try
            {
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Goods_Info>)bf.Deserialize(f);
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
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }
            message = "Запись выполнена";
        }
    }
}
