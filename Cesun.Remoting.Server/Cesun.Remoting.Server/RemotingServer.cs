using System;
namespace Cesun.Remoting.Server
{
	[Serializable]
	public class TaskCompleteEventArgs: EventArgs
	{
		public object Result { get; set; }
		public TaskCompleteEventArgs (object result)
		{
			Result = result;
		}
	}
	
	
	public delegate void TaskCompleteEventHandler(object sender, TaskCompleteEventArgs e);
	public class RemotingServer : MarshalByRefObject
	{
		private int counter = 0;
		public event TaskCompleteEventHandler TaskComplete;
		 
		public RemotingServer ()
		{
			Console.WriteLine("Me han creado");
		}
		
		public void OnTaskComplete(object message)
		{
			if(TaskComplete != null)
				TaskComplete(this, new TaskCompleteEventArgs(message));
		}
		
		public string GetActiveDomain()
		{
			Console.WriteLine("Recibi una llamada remota");
			counter++;
			
			return String.Format("Mi proceso es {0} - {1}",
			                     AppDomain.CurrentDomain.FriendlyName,
			                     counter);
		}
		
		
		public void LongRunning()
		{
			System.Threading.Thread.Sleep(3000);
			OnTaskComplete("Ya termino el proceso");
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

