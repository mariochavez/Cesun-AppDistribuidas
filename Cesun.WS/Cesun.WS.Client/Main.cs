using System;

namespace Cesun.WS.Client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello Webservice!");
			
			Console.WriteLine("Dame primer valor a sumar:");
			int value1 = Int32.Parse(Console.ReadLine());
			
			Console.WriteLine("Dame segundo valor a sumar:");
			int value2 = Int32.Parse(Console.ReadLine());
			
			localhost.Servidor ws = new localhost.Servidor();
			int result1 = ws.Suma(value1, value2);
			int result2 = ws.Multiplicacion(value1, value2);
			
			Console.WriteLine(
			                  String.Format("El resultado de la suma es: {0}", 
			                                result1));
			
			Console.WriteLine(
			                  String.Format("El resultado de la multiplicacion es: {0}", 
			                                result2));
		}
	}
}

