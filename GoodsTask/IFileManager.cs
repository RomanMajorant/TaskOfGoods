using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsTask
{
    public interface IFileManager
    {
        bool PrintToFile(List<Goods_Info> list, string fileName);//done
        List<Goods_Info> LoadFromFile(string fileName);
    }
}
