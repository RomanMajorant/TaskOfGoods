using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace GoodsTask
{
    class XmlFIle : IFileManager
    {
        public List<Goods_Info> LoadFromFile(string fileName)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Goods_Info>));
                    return (List<Goods_Info>)s.Deserialize(reader);
                }
            }

            catch
            {
                throw new Exception("Такого файла не существует или файл пустой"); //жесткое исключение. Делал для проверки файла на существование, но для этого есть FileExists
            }
        }

        public void PrintToFile(List<Goods_Info> list, string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Goods_Info>));
                s.Serialize(writer, list);
                writer.Close();
            }
            Console.WriteLine("Запись выполнена");//обращения к консоли не должно быть отсюда
        }
    }
}
