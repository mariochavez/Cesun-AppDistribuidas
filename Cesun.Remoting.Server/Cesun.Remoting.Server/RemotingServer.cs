using System;
namespace Cesun.Remoting.Server
{
	public class RemotingServer : MarshalByRefObject
	{
		private int counter = 0;
		
		public RemotingServer ()
		{
			Console.WriteLine("Me han creado");
		}
		
		public string GetActiveDomain()
		{
			Console.WriteLine("Recibi una llamada remota");
			counter++;
			
			//System.Threading.Thread.Sleep(3000);
			
			return String.Format("Mi proceso es {0} - {1}",
			                     AppDomain.CurrentDomain.FriendlyName,
			                     counter);
		}
		
		public Person FindPerson(int id)
		{
			Person p = new Person {
				Name = "Un nombre",
				Address = "Una direccion",
				Password = "Secreto"
			};
			return p;
		}
	}
}

