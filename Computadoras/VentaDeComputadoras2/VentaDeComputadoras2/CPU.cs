using System;

namespace VentaDeComputadoras2
{
	public class CPU: Component
	{
		public CPU(String manufacturerName, String model, float price):
			base(manufacturerName, model, price)
		{
			this.componentName = "CPU";
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

