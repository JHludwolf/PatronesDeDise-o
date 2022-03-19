using System;
namespace VentaDeComputadoras2
{
	public class Touchscreen: Component
	{
		public Touchscreen(String manufacturerName, String model, float price) :
			base(manufacturerName, model, price)
		{
			this.componentName = "Touchscreen";
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

