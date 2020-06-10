using System.Collections.Generic;//Коллекции и все такое


namespace GoodsTask
{
    public interface IFileManager
    {
        void PrintToFile(List<Goods_Info> list, string fileName, out bool FlagMessage);
        List<Goods_Info> LoadFromFile(string fileName);
    }
}
