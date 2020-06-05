using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    [Serializable]
    public class Tour_Info
    {
        /*public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public DateTime Departure_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public Double Price { get; set; }*/
        public string Name { get; set; }
        public string TypeGoods { get; set; }
        public int Price { get; set; }
        public int CountGoods{ get; set; }
        public DateTime ShelfLife { get; set; }




        public Tour_Info(string name, string typegoods, int price, int countgoods, DateTime shelflife)
        {
            this.Name = name;
            this.TypeGoods = typegoods;
            this.Price = price;
            this.CountGoods = countgoods;
            this.ShelfLife = shelflife;
        }

        public Tour_Info() { }

        public override string ToString()
        {
            return String.Format("Название: {0}, Тип товара: {1}, Цена: {2},\nКол-во товара: {3}, Срок хранения:{4}\n",
                Name, TypeGoods, Price.ToString(), CountGoods, ShelfLife.ToShortDateString());
        }
    }
}
