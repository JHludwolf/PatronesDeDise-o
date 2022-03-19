using System;
namespace VentaDeComputadoras2
{
	public class Printer: OutputDevice
	{
		private String printerType;
		private String tonerType;

		public Printer(String manufacturerName, String model, float price, int[] validPorts, String printerType, String tonerType) :
			base(manufacturerName, model, price, validPorts)
		{
			this.printerType = printerType;
			this.tonerType = tonerType;
			this.componentName = "Printer";
		}
	}
}

