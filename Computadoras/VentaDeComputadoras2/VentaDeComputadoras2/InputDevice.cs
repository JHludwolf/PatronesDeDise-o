using System;
namespace VentaDeComputadoras2
{
	public abstract class InputDevice: Component
	{
		protected String connectorType;
		protected int[] validPorts;

		public InputDevice(String manufacturerName, String model, float price, String connectorType, int[] validPorts) :
			base(manufacturerName, model, price)
		{
			this.connectorType = connectorType;
			this.validPorts = validPorts;
		}

		public override void ShowInfo()
        {
			Console.WriteLine(componentName);
			Console.WriteLine("Manufacturer Name: " + this.manufacturerName);
			Console.WriteLine("Model: " + this.model);
			Console.WriteLine("Price: " + this.price.ToString());
			Console.WriteLine("Connector Type: " + this.connectorType);
		}
	}
}

