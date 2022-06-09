using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Drawing;
using VisioForge.Types;
using Newtonsoft.Json.Linq;
using ProyectoFinal;

namespace MyApp
{

    class Program
    {
        static void Main(string[] args)
        {
            App MainApp = new App();

            MainApp.Login();
            /*
            QRCode scanner = new QRCode();

            //string res = scanner.ReadQR("?fileurl=http%3A%2F%2Fapi.qrserver.com%2Fv1%2Fcreate-qr-code%2F%3Fdata%3DHelloWorld");
            //string res = scanner.ReadQR("?fileurl=http://api.qrserver.com/v1/create-qr-code/?data=Pedido%201%20de%20Tijuana&size=100x100");
            //Console.WriteLine(res);

            //bool state = scanner.CreateQR("Example");
            //Console.Write(state);

            Product soda = new Product(10001, "Soda", 5.0f);
            Product bread = new Product(10002, "Bread", 3.5f);
            Product vegetables = new Product(10003, "Vegatables", 9.0f);

            Distributor distributor1 = new Distributor(20001, "Abarrotes Don Jose");

            distributor1.AddProduct(soda, 50);
            distributor1.AddProduct(bread, 30);
            distributor1.AddProduct(vegetables, 15);

            Distributor distributor2 = new Distributor(20002, "Super Market Flores");

            distributor2.AddProduct(soda, 10);
            distributor2.AddProduct(vegetables, 5);

            Distributor distributor3 = new Distributor(20003, "Tiendita Majo");

            distributor3.AddProduct(soda, 150);

            //Console.WriteLine(distributor.OrderToJSON());

            Supplier supplier = new Supplier(30001, "Bimbo");

            supplier.AddProduct(soda);
            supplier.AddProduct(bread);
            supplier.AddProduct(vegetables);

            for (int i = 0; i < 3; i++) {
                supplier.AddVehicle(new DeliveryTruck(120.0f), 10001);
                supplier.AddVehicle(new DeliveryTruck(270.0f), 10002);
                supplier.AddVehicle(new DeliveryTruck(95.0f), 10003);
            } */

            /*foreach (KeyValuePair<int,List<DeliveryVehicle>> category in supplier.vehicles)
            {
                Console.WriteLine(category.Key);
                foreach(DeliveryVehicle vehicle in category.Value)
                {
                    Console.WriteLine(vehicle.VehicleID);
                }
            }*/
            /*supplier.ScanQRCodeFromDistributor(distributor1);
            supplier.ScanQRCodeFromDistributor(distributor2);
            supplier.ScanQRCodeFromDistributor(distributor3);

            Dictionary<int, List<DeliveryVehicle>> vehiclesSimulation1 = new Dictionary<int, List<DeliveryVehicle>>()
            {
                { 10001, new List<DeliveryVehicle>() { new DeliveryTruck(120.0f), new DeliveryTruck(120.0f), new DeliveryTruck(120.0f) } },
                { 10002, new List<DeliveryVehicle>() { new DeliveryTruck(270.0f) } },
                { 10003, new List<DeliveryVehicle>() { new DeliveryTruck(95.0f), new DeliveryTruck(95.0f) } }
            };

            Dictionary<int, List<DeliveryVehicle>> vehiclesSimulation2 = new Dictionary<int, List<DeliveryVehicle>>()
            {
                { 10001, new List<DeliveryVehicle>() { new DeliveryTruck(120.0f) } },
                { 10002, new List<DeliveryVehicle>() { new DeliveryTruck(270.0f) } },
                { 10003, new List<DeliveryVehicle>() { new DeliveryTruck(95.0f) } }
            };


            Console.WriteLine(supplier.CanSupplyOrders(vehiclesSimulation1));
            Console.WriteLine(supplier.CanSupplyOrders(vehiclesSimulation2));

            //Dictionary<int, int> order = supplier.ReadQROrder(distributor1.OrderToQRCode());*/

            /*supplier.ScanQRCodeFromDistributor(distributor1);
            supplier.ScanQRCodeFromDistributor(distributor2);
            supplier.ScanQRCodeFromDistributor(distributor3);

            Dictionary<int, Dictionary<int,int>> sortedOrders = supplier.SortedOrders();

            foreach(KeyValuePair<int,Dictionary<int,int>> order in sortedOrders)
            {
                Console.WriteLine(order.Key);
            }*/
            //Console.WriteLine(String.Format("Total: {0}", total));

        }
    }
}