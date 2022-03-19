using System;
namespace VentaDeComputadoras2
{
	public abstract class Component
	{
		protected String manufacturerName;
		protected String model;
		public float price { get; private set; }
		protected String componentName;

		public Component(String manufacturerName, String model, float price)
		{
			this.manufacturerName = manufacturerName;
			this.model = model;
			this.price = price;
		}

		public abstract void ShowInfo();
	}
}

