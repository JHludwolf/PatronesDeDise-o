using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class Supplier: User
    {
        /* Dictionary<int,int> order; ProductID, amount */
        /* Dictionary<int, Dictionary<int, int>> orders; DistributorID, order */
        /* Dictionary<int, DeliveryVehicle> vehicles; ProductID, List<DeliveryVehicle>*/
        /* Dictionary<int, Product> products; ProductID, Product*/

        public Dictionary<int, Dictionary<int, int>> orders = new Dictionary<int, Dictionary<int, int>>();
        
        public Dictionary<int, List<DeliveryVehicle>> vehicles = new Dictionary<int, List<DeliveryVehicle>>();

        public Dictionary<int, Product> Products = new Dictionary<int, Product>();

        private QRCode scanner = new QRCode();

        public Supplier(int UserID, string UserName): base(UserID, UserName)
        {

            vehicles = new Dictionary<int, List<DeliveryVehicle>>() {
                { 10001, new List<DeliveryVehicle>() },
                { 10002, new List<DeliveryVehicle>() },
                { 10003, new List<DeliveryVehicle>() }
            };

            Products = new Dictionary<int, Product>()
            {
                { 10001, new Product(10001, "Soda", 5.0f) },
                { 10002, new Product(10002, "Bread", 3.5f) },
                { 10003, new Product(10003, "Vegatables", 9.0f) }
            };
        }

        private void AddToOrders(int distributorID, string QRCode)
        {

            orders.Add(distributorID, ReadQROrder(QRCode));
        }
        public void ScanQRCodeFromDistributor(Distributor client)
        {
            AddToOrders(client.DistributorID, client.CurrentQROrder);
        }

        public void SimulateDelivery()
        {
            //foreach (var item in orders)
        }

        public Dictionary<int, int> ReadQROrder(string qrcode)
        {
            string jsonString = scanner.ReadQR(qrcode);
            Dictionary<int, int> order = JsonSerializer.Deserialize<Dictionary<int, int>>(jsonString);

            //foreach (KeyValuePair<int, int> pair in order) Console.WriteLine(string.Format("{0}:{1}", pair.Key, pair.Value));
            return order;
        }

        public void AddVehicle(DeliveryVehicle vehicle, int productID)
        {
            int index = 0;
            foreach(List<DeliveryVehicle> vehicles in vehicles.Values) index += vehicles.Count;
            vehicle.VehicleID = 40001 + index;
            vehicles[productID].Add(vehicle);

        }

        public void AddProduct(Product product)
        {
            Products.Add(product.ProductID, product);
        }

        public float CalculateOrderTotal(Dictionary<int, int> order)
        {
            float total = 0;

            foreach (KeyValuePair<int, int> product in order)
            {
                //if(products.ContainsKey(product.Key)) 
                total += Products[product.Key].Price * product.Value;
            }

            return total;
        }

        public Dictionary<int, Dictionary<int, int>> SortedOrders()
        {
            List<Dictionary<int, int>> ordersList = new List<Dictionary<int, int>>(orders.Values.ToList());
            List<int> distributors = new List<int>(orders.Keys.ToList());

            Dictionary<int, int> tempDict;
            int tempInt;

            for (int j = 0; j <= ordersList.Count - 2; j++)
            {
                for (int i = 0; i <= ordersList.Count - 2; i++)
                {
                    if (CalculateOrderTotal(ordersList[i]) < CalculateOrderTotal(ordersList[i + 1]))
                    {
                        tempDict = ordersList[i + 1];
                        ordersList[i + 1] = ordersList[i];
                        ordersList[i] = tempDict;

                        tempInt = distributors[i + 1];
                        distributors[i + 1] = distributors[i];
                        distributors[i] = tempInt;
                    }
                }
            }

            Dictionary<int, Dictionary<int, int>> sortedOrders = distributors.Zip(ordersList, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            return sortedOrders;
        }

        public bool CanSupplyOrders(Dictionary<int, List<DeliveryVehicle>> vehiclesSimulation)
        {
            // ProdID, amount

            foreach(var vehicle in vehiclesSimulation)
            {
                float capacity = 0;
                float demand = 0;
                float individualCpacity = vehicle.Value[0].maxCapacity;
                capacity += vehicle.Value.Count * individualCpacity;
                

                foreach (Dictionary<int, int> order in orders.Values)
                {
                    foreach (var product in order)
                    {
                        if (product.Key == vehicle.Key) demand += product.Value;
                    }
                }
                //Console.WriteLine(String.Format("Product {0}: Capacity: {1}", vehicle.Key, capacity));
                //Console.WriteLine(String.Format("Product {0}: Demand: {1}", vehicle.Key, demand));
                if(demand > capacity) return false;
            }
            return true;
        }

        private void Deliver()
        {

        }

    }
}
