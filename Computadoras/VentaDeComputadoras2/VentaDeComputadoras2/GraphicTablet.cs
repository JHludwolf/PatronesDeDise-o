using System;
namespace VentaDeComputadoras2
{
	public class GraphicTablet: InputDevice
	{
		public GraphicTablet(String manufacturerName, String model, float price, String connectorType, int[] validPorts) :
			base(manufacturerName, model, price, connectorType, validPorts)
		{
			this.componentName = "Graphic Tablet";
		}
	}
}

