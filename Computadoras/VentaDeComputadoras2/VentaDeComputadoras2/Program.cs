using System;

namespace VentaDeComputadoras2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("ARMA TU COMPUTADORA");

            Director director = new Director();

            ComputerBuilder b1 = new ComputerBuilder();

            director.Construct(b1);
        }
    }
}
