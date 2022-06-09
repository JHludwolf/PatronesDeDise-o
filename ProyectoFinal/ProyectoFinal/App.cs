using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class App
    {
        public Dictionary<int, Distributor> Distributors;

        public Dictionary<int, Supplier> Suppliers;

        public Dictionary<int, Product> Products;

        public Dictionary<int, DeliveryVehicle> Vehicles;

        public bool CanDeliver;

        public App()
        {
            Suppliers = new Dictionary<int, Supplier>()
            {
                {30001, new Supplier(30001, "Kirkland") }
            };

            Distributors = new Dictionary<int, Distributor>()
            {
                { 20001, new Distributor(20001, "Abarrotes Don Jose") },
                { 20002, new Distributor(20002, "Super Market Flores") },
                { 20003, new Distributor(20003, "Tiendita Majo") }
            };

            Products = new Dictionary<int, Product>()
            {
                { 10001, new Product(10001, "Soda", 5.0f) },
                { 10002, new Product(10002, "Bread", 3.5f) },
                { 10003, new Product(10003, "Vegatables", 9.0f) }
            };

            Vehicles = new Dictionary<int, DeliveryVehicle>()
            {
                { 10001, new DeliveryTruck(120.0f) },
                { 10002, new DeliveryTruck(270.0f) },
                { 10003, new DeliveryTruck(95.0f) }
            };

            CanDeliver = true;
        }

        public void Login()
        {
            while (true)
            {
                int input;
                Console.WriteLine("Welcome to the App");
                Console.WriteLine("Please introduce your user type:");
                Console.WriteLine("1. Distributor");
                Console.WriteLine("2. Supplier");

                input = Input();

                if (input == 1)             // Is Distributor
                {
                    Console.WriteLine("Welcome Distriburor.");
                    Console.WriteLine("Enter your User ID");
                    int DistributorID;
                    do
                    {
                        DistributorID = Input();
                        if (Distributors.ContainsKey(DistributorID))
                        {
                            Console.WriteLine("Scanning User QR Code...");
                            if (Distributors[DistributorID].AuthenticateWithQR(Distributors[DistributorID].GetUserQRCode()))
                            {
                                Console.WriteLine("Succesful authentication!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Authentication Failed. Try Again:");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Unknown User. Try Again:");
                        }
                    } while (true);

                    DistributorCaptureOrder(DistributorID);


                }
                else if (input == 2)      // Is Supplier
                {
                    Console.WriteLine("Welcome Supplier.");
                    Console.WriteLine("Enter your User ID");
                    int SupplierID;
                    do
                    {
                        SupplierID = Input();
                        if (Suppliers.ContainsKey(SupplierID))
                        {
                            Console.WriteLine("Scanning User QR Code...");
                            if (Suppliers[SupplierID].AuthenticateWithQR(Suppliers[SupplierID].GetUserQRCode()))
                            {
                                Console.WriteLine("Succesful authentication!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Authentication Failed. Try Again:");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Unknown User. Try Again:");
                        }
                    } while (true);

                    SupplierMenu(SupplierID);
                }
            }
            
            
        }

        public void SupplierMenu(int SupplierID)
        {
            Console.WriteLine($"Welcome {Suppliers[SupplierID].UserName}!");
            Console.WriteLine("What to you want to do?:");
            int input;

            do
            {
                Console.WriteLine("1. Simulate Delivery");
                Console.WriteLine("2. Deliver Orders");
                Console.WriteLine("0. Exit");
                do
                {
                    input = Input();
                    if (input == 1 || input == 2 || input == 0 ) break;
                    else Console.WriteLine("Invalid Selection. Try Again:");
                } while (true);
                
                if(input == 1)
                {
                    if (Suppliers[SupplierID].orders.Count == 0) Console.WriteLine("No current orders to simulate.");
                    else SupplierSimulateDelivery(SupplierID);  
                } else if(input == 2)
                {
                    if (!CanDeliver) Console.WriteLine("Can not deliver until simulation is satisfied.");
                    else SupplierDeliver(SupplierID);
                } else if(input == 0)
                {
                    Console.WriteLine($"Good bye {Suppliers[SupplierID].UserName}!");
                    break;
                }

            } while (true);
        }

        public void SupplierDeliver(int SupplierID)
        {
           

            if(Suppliers[SupplierID].orders.Count == 0)
            {
                Console.WriteLine("No current orders to deliver.");
                Console.WriteLine("Visiting all stores to take orders!");

                foreach (int DistributorID in Distributors.Keys)
                {
                    if (Distributors.ContainsKey(DistributorID))
                    {
                        Console.WriteLine($"Visiting {Distributors[DistributorID].DistributorName}...");
                        Console.WriteLine("Scanning Distributor QR Order Code...");
                        Suppliers[SupplierID].ScanQRCodeFromDistributor(Distributors[DistributorID]);
                        Console.WriteLine($"{Distributors[DistributorID].DistributorName} QR Order Code scanned succesfully!");
                    }
                }
                Console.WriteLine("All orders have been collected!");
            } else
            {
                Dictionary<int, Dictionary<int, int>> sortedOrders;
                sortedOrders = Suppliers[SupplierID].SortedOrders();

                Suppliers[SupplierID].orders.Clear();

                foreach (int DistributorID in sortedOrders.Keys)
                {
                    if (Distributors.ContainsKey(DistributorID))
                    {
                        if(Suppliers[SupplierID].orders.ContainsKey(DistributorID)) Console.WriteLine($"Delivering to {Distributors[DistributorID].DistributorName}...");
                        else Console.WriteLine($"Visiting {Distributors[DistributorID].DistributorName}...");
                        Console.WriteLine("Scanning Distributor QR Order Code...");
                        Suppliers[SupplierID].ScanQRCodeFromDistributor(Distributors[DistributorID]);
                        Console.WriteLine($"{Distributors[DistributorID].DistributorName} QR Order Code scanned succesfully!");
                    }
                }
                Console.WriteLine("All orders have been delivered!");
            }

            CanDeliver = false;

            return;
        }

        public void SupplierSimulateDelivery(int SupplierID)
        {
            do
            {
                Dictionary<int, List<DeliveryVehicle>> vehiclesSimulation = new Dictionary<int, List<DeliveryVehicle>>();
                //{ 10001, new List<DeliveryVehicle>() }
                int noOfTrucks;
                foreach (KeyValuePair<int, Product> product in Products)
                {
                    List<DeliveryVehicle> productVehicles = new List<DeliveryVehicle>();
                    Console.WriteLine($"Enter the numer of {Products[product.Key].Name} trucks: (1-3)");

                    do
                    {
                        noOfTrucks = Input();
                        if (noOfTrucks >= 1 && noOfTrucks <= 3) break;
                        else Console.WriteLine("Invalid Amount. Try Again:");
                    } while (true);

                    Console.WriteLine($"Adding {noOfTrucks} {Products[product.Key].Name} trucks.");
                    for (int i = 0; i < noOfTrucks; i++)
                    {
                        productVehicles.Add(Vehicles[product.Key]);
                    }
                    vehiclesSimulation.Add(product.Key, productVehicles);
                }

                if (Suppliers[SupplierID].CanSupplyOrders(vehiclesSimulation))
                {
                    Console.WriteLine("Delivery requirements satisfied!");
                    Console.WriteLine("You can now deliver!");
                    CanDeliver = true;
                    break;
                }
                else Console.WriteLine("Delivery requirements are not satisfied. Try Again:");
            } while (true);
            
            return;
        }

        public void DistributorCaptureOrder(int DistributorID)
        {
            Distributors[DistributorID].order.Clear();
            Console.WriteLine($"Welcome {Distributors[DistributorID].UserName}!");
            Console.WriteLine("Capture Order:");
            int input;

            do
            {
                Console.WriteLine("Enter the product ID:");
                int ProductID;
                do
                {
                    ProductID = Input();
                    if (Products.ContainsKey(ProductID))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Unknown Product. Try Again:");
                    }
                } while (true);

                Console.WriteLine($"Enter the number of {Products[ProductID].Name}:");
                int amount;
                do
                {
                    amount = Input();
                    if (amount > 0) break;
                    else Console.WriteLine("Invalid Amount. Try Again:");
                } while (true);


                Distributors[DistributorID].AddProduct(Products[ProductID], amount);

                Console.WriteLine("Order:");
                foreach (KeyValuePair<int, int> product in Distributors[DistributorID].order)
                {
                    Console.WriteLine($"Product: {Products[product.Key].Name}, Amount: {product.Value}");
                }

                Console.WriteLine("Do you want to keep adding products? (Y=1 / N=0)");
                do
                {
                    input = Input();
                    if (input == 1 || input == 0) break;
                    else Console.WriteLine("Invalid Answer. Try Again:");
                } while (true);

                if (input == 0)
                {
                    Console.WriteLine("Generating QR Order Code...");
                    Distributors[DistributorID].UpdateQROrder();
                    Console.WriteLine("Succesful Order QR Code Generation!");
                    Console.WriteLine($"Good bye {Distributors[DistributorID].UserName}!");
                    break;
                }

            } while (true);
        }

        public int Input()
        {
            string input = String.Empty;
            int result;

            do
            {
                try
                {
                    input = Console.ReadLine();
                    result = Int32.Parse(input);
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong Input. Try Again: ");
                }
            } while (true);
        }
    }
}
