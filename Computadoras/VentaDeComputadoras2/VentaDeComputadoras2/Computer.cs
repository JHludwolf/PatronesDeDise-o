using System;
using System.Collections.Generic;

namespace VentaDeComputadoras2
{
	public class Computer
	{
		public CPU centralUnit { get; set; }
		public List<InputDevice> inputDevices = new ();
		public List<OutputDevice> outputDevices = new();
		public List<Touchscreen> touchscreens = new();

		/*public Computer(CPU centralUnit, InputDevice[] inputDevices, OutputDevice[] outputDevices)
		{
			this.centralUnit = centralUnit;

			foreach (InputDevice id in inputDevices)
			{
				this.inputDevices.Add(id);
			}

			foreach (OutputDevice od in outputDevices)
			{
				this.outputDevices.Add(od);
			}

		}*/

		public float Price()
        {
			float totalPrice = 0f;

			if(centralUnit != null) totalPrice += centralUnit.price;

			foreach (InputDevice id in inputDevices)
			{
				totalPrice += id.price;
			}

			foreach (OutputDevice od in outputDevices)
			{
				totalPrice += od.price;
			}

			foreach (Touchscreen ts in touchscreens)
			{
				totalPrice += ts.price;
			}

			return totalPrice;
        }
	}
}

