using System;
namespace VentaDeComputadoras2
{
	public class Keyboard: InputDevice
	{
		public Keyboard(String manufacturerName, String model, float price, String connectorType, int[] validPorts) :
			base(manufacturerName, model, price, connectorType, validPorts)
		{
			this.componentName = "Keyboard";
		}
	}
}

