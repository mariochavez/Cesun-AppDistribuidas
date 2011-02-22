using System;
using System.Runtime.Remoting;

namespace Cesun.Remoting.Server
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Iniciando servidor de remoting!");
			
			RemotingConfiguration.Configure("Server.exe.config");
			                   
			Console.WriteLine("Presione ENTER para terminar....");
			Console.ReadLine();
		}
	}
}

