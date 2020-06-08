using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsTask
{
    public interface IFileManager
    {
        void PrintToFile(List<Goods_Info> list, string fileName);
        List<Goods_Info> LoadFromFile(string fileName);
    }
}
