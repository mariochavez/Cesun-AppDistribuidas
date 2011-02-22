using System;
namespace Cesun.Remoting.Server
{
	[Serializable]
	public class Person
	{
		public Person ()
		{
		}
		
		public string Name { get; set; }
		public string Address { get; set; }
		
		[NonSerialized]
		private string password;
		public string Password { 
			get { return password; } 
			set { password = value; } 
		}
	}
}

