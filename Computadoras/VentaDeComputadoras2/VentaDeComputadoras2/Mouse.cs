using System;
namespace VentaDeComputadoras2
{
	public class Mouse: InputDevice
	{
		public Mouse(String manufacturerName, String model, float price, String connectorType, int[] validPorts) :
			base(manufacturerName, model, price, connectorType, validPorts)
		{
			this.componentName = "Mouse";
		}
	}
}

