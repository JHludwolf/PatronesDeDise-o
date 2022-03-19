using System;
namespace VentaDeComputadoras2
{
	public class Monitor: OutputDevice
	{
		public Monitor(String manufacturerName, String model, float price, int[] validPorts) :
			base(manufacturerName, model, price, validPorts)
		{
			this.componentName = "Monitor";
		}
	}
}

