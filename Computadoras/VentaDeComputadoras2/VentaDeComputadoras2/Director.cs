using System;
using System.Collections.Generic;

namespace VentaDeComputadoras2
{
	public class Director
	{

        static List<CPU> centralUnits = new () {
            new CPU("Intel", "i5-10400", 3590.00f),
            new CPU("AMD", "5 5600X", 5099.00f)
        };

        static List<OutputDevice> outputDevices = new ()
        {
            new Monitor("HUAWEI", "Display 23.8", 3199.00f, new int[] { 4, 5}),
            new Monitor("LG", "27MP60G-B", 4620.16f, new int[] {5}),
            new Printer("Canon", "G1110", 2998.99f, new int[] { 1, 2, 3}, "Inyection", "GI-190"),
            new Printer("HP", "M111w", 2900.00f, new int[] { 1, 2, 3}, "Laser", "662XL")


        };

        static List<InputDevice> inputDevices = new () {
            new Mouse("Logitech", "G502", 703.63f, "USB", new int[] { 1, 2, 3 }),
            new Mouse("HyperX", "Pulsefire Surge", 998.99f, "USB", new int[] { 1, 2, 3 }),
            new Keyboard("Razer", "Cynosa Chroma", 1184.82f, "USB", new int[] { 1, 2, 3 }),
            new Keyboard("HyperX", "Alloy Origins", 2448.45f, "USB", new int[] { 1, 2, 3 }),
            new GraphicTablet("VEIKK", "A15Pro", 1799.31f, "USB", new int[] { 1, 2, 3 }),
            new GraphicTablet("Wacom", "CTL472", 1099.00f, "USB", new int[] { 1, 2, 3 })
        };

        static List<Touchscreen> touchscreens = new()
        {
            new Touchscreen("HMTECH", "10,1 pulgadas", 2580.85f),
            new Touchscreen("Cocopar", "15.6 pulgadas", 5623.94f)
        };

        public void Construct(ComputerBuilder builder)
		{
            int input = -1;
            while(input != 0)
            {
                Console.WriteLine("1. Elegir CPU");
                Console.WriteLine("2. Añadir Dispositivo de Entrada");
                Console.WriteLine("3. Añadir Dispositivo de Salida");
                Console.WriteLine("4. Añadir TouchScreen");
                Console.WriteLine("5. Eliminar Dispositivo de Entrada");
                Console.WriteLine("6. Eliminar Dispositivo de Salida");
                Console.WriteLine("7. Eliminar TouchScreen");
                Console.WriteLine("8. Calcular Total");
                Console.WriteLine("0. Salir");

                input = Convert.ToInt32(Console.ReadLine());

                int selection;

                switch (input)
                {
                    case 1:
                        selection = ShowCPU(centralUnits);
                        builder.SetCPU(centralUnits[selection]);
                        break;
                    case 2:
                        selection = ShowInputDevices(inputDevices);
                        builder.AddInputDevice(inputDevices[selection]);
                        break;
                    case 3:
                        selection = ShowOutputDevices(outputDevices);
                        builder.AddOutputDevice(outputDevices[selection]);
                        break;
                    case 4:
                        selection = ShowTouchscreens(touchscreens);
                        builder.AddTouchscreen(touchscreens[selection]);
                        break;
                    case 5:
                        selection = ShowInputDevices(builder.GetComputer().inputDevices);
                        if(selection != -1) builder.GetComputer().inputDevices.RemoveAt(selection);
                        break;
                    case 6:
                        selection = ShowOutputDevices(builder.GetComputer().outputDevices);
                        if (selection != -1) builder.GetComputer().outputDevices.RemoveAt(selection);
                        break;
                    case 7:
                        selection = ShowTouchscreens(builder.GetComputer().touchscreens);
                        if (selection != -1) builder.GetComputer().touchscreens.RemoveAt(selection);
                        break;
                    case 8:
                        Console.WriteLine("$" + builder.GetComputer().Price().ToString());
                        break;
                    case 0:
                        Console.WriteLine("¡Gracias por su compra!");
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;
                }
            }
        }

        private int ShowCPU(List<CPU> list)
        {
            if(list.Count == 0)
            {
                Console.WriteLine("No tienes nada en lista");
                return -1;
            }
            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine("Item: " + (i+1).ToString());
                list[i].ShowInfo();
            }

            Console.WriteLine("Enter the number of the item to select:");

            int input = -1;

            do
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (input >= list.Count);

            return input;
        }

        private int ShowOutputDevices(List<OutputDevice> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No tienes nada en lista");
                return -1;
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Item: " + (i + 1).ToString());
                list[i].ShowInfo();
            }

            Console.WriteLine("Enter the number of the item to select:");

            int input = -1;

            do
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (input >= list.Count);

            return input;
        }

        private int ShowInputDevices(List<InputDevice> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No tienes nada en lista");
                return -1;
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Item: " + (i + 1).ToString());
                list[i].ShowInfo();
            }

            Console.WriteLine("Enter the number of the item to select:");

            int input = -1;

            do
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (input >= list.Count);

            return input;
        }

        private int ShowTouchscreens(List<Touchscreen> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No tienes nada en lista");
                return -1;
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Item: " + (i + 1).ToString());
                list[i].ShowInfo();
            }

            Console.WriteLine("Enter the number of the item to select:");

            int input = -1;

            do
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (input >= list.Count);

            return input;
        }
    }
}

