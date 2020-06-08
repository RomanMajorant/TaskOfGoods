using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GoodsTask
{
    [Serializable]
    public class Goods_Info
    {
        public string Name { get; set; }
        public string TypeGoods { get; set; }
        public int Price { get; set; }
        public int CountGoods { get; set; }
        public DateTime ShelfLife { get; set; }




        public Goods_Info(string name, string typegoods, int price, int countgoods, DateTime shelflife)
        {
            this.Name = name;
            this.TypeGoods = typegoods;
            this.Price = price;
            this.CountGoods = countgoods;
            this.ShelfLife = shelflife;
        }

        public Goods_Info() { }

        public override string ToString()
        {
            return String.Format("Название: {0}, Тип товара: {1}, Цена: {2},\nКол-во товара: {3}, Срок хранения:{4}\n",
                Name, TypeGoods, Price.ToString(), CountGoods, ShelfLife.ToShortDateString());
        }
    }
}
