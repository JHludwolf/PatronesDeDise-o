using System;
namespace VentaDeComputadoras2
{
	public abstract class OutputDevice : Component
	{
		protected int[] validPorts;

		public OutputDevice(String manufacturerName, String model, float price, int[] validPorts) :
			base(manufacturerName, model, price)
		{
			this.validPorts = validPorts;
		}

		public override void ShowInfo()
		{
			Console.WriteLine(componentName);
			Console.WriteLine("Manufacturer Name: " + this.manufacturerName);
			Console.WriteLine("Model: " + this.model);
			Console.WriteLine("Price: " + this.price.ToString());
		}
	}
}

