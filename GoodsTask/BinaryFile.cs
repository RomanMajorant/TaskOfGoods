using System;//область имен с системными базовыми классами
using System.Collections.Generic;//Коллекции и все такое
using System.IO;//для записи и чтения файлов, ввода и вывода данных
using System.Runtime.Serialization.Formatters.Binary;


namespace GoodsTask
{
    class BinaryFile : IFileManager
    {
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Goods_Info>)bf.Deserialize(f);
                }
            }
            else
            {
                throw new Exception("Такого файла не существует");
            }
        }

        public bool PrintToFile(List<Goods_Info> list, string fileName)//done
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }
            return true;
        }
    }
}
