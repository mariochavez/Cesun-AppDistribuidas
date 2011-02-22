using System;
using System.Runtime.Remoting;
using Cesun.Remoting.Server;

namespace Cesun.Remoting.Client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Cliente de remoting!");
			RemotingConfiguration.Configure("RemotingServer.config");
			
			RemotingServer server = new RemotingServer();
			
			
			bool shouldExit = false;
			
			do {
				Person p = server.FindPerson(0);
				Console.WriteLine(String.Format("Resultado de la llamada al server: {0}", 
			                                server.GetActiveDomain() ));
				
				Console.WriteLine("Exit: (N)");
				string ret = Console.ReadLine();
				shouldExit = (ret == "S");
			} while (!shouldExit);
		}
	}
}

