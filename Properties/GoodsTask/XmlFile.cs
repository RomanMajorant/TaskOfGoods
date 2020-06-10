using System;//область имен с системными базовыми классами
using System.Collections.Generic;//Коллекции и все такое
using System.Xml;//Работа с файлами xml
using System.Xml.Serialization;//Преобразования открытых свойств и полей обектов в формат для хранения и преобразований 
using System.IO;//для записи и чтения файлов, ввода и вывода данных


namespace GoodsTask
{
    class XmlFIle : IFileManager
    {
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Goods_Info>));
                    return (List<Goods_Info>)s.Deserialize(reader);
                }
            }
            else
            {
                throw new Exception("Такого файла не существует");
            }
        }

        public void PrintToFile(List<Goods_Info> list, string fileName, out bool FlagMessage)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Goods_Info>));
                s.Serialize(writer, list);
                writer.Close();
            }
            FlagMessage = true;
        }
    }
}
