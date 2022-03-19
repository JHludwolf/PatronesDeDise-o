using System;
namespace VentaDeComputadoras2
{
	public class ComputerBuilder
	{
		private Computer computer = new Computer();

		public void SetCPU(CPU centralUnit)
        {
			computer.centralUnit = centralUnit;
        }

		public void AddInputDevice(InputDevice inputDevice)
        {
			computer.inputDevices.Add(inputDevice);
        }

		public void AddOutputDevice(OutputDevice outputDevice)
        {
			computer.outputDevices.Add(outputDevice);
        }

		public void AddTouchscreen(Touchscreen touchscreen)
		{
			computer.touchscreens.Add(touchscreen);
		}

		public Computer GetComputer()
        {
			return computer;
        }
	}
}

