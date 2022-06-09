using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Product
    {
        public string Name { get; set; }
        public int ProductID { get; set; }
        public float Price { get; set; }

        public Product(int ProductID, String Name,float Price)
        {
            this.ProductID = ProductID;
            this.Name = Name;
            this.Price = Price;
        }
    }
}
