using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


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
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Goods_Info>));
                s.Serialize(writer, list);
                writer.Close();
            }
            message = "Запись выполнена";
        }
    }
}
