using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Distributor: User
    {
        public Dictionary<int, int> order = new Dictionary<int, int>();
        //public List<string> QROrders = new List<string>();

        private  QRCode scanner = new QRCode();

        public string CurrentQROrder;

        public Distributor(int UserID, string UserName): base(UserID, UserName)
        {
            UpdateQROrder();
        }

        public void AddProduct(Product product, int amount)
        {
            if(!order.ContainsKey(product.ProductID)) order.Add(product.ProductID, amount);
            else {
                order[product.ProductID] += amount;
            }
        }

        public string OrderToJSON()
        {
            return JsonSerializer.Serialize(order);
        }

        private string OrderToQRCode()
        {
            string qrCode = OrderToJSON();
            return scanner.CreateQR(qrCode);
        }

        public void UpdateQROrder()
        {
            CurrentQROrder = OrderToQRCode();
        }
    }
}
