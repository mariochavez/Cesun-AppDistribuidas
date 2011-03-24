using System;
using System.Web;
using System.Web.Services;

namespace Cesun.WS.Server
{
	[WebService(Namespace = "http://www.cesun.edu", 
	            Description = "Servidor de prueba")]
	public class Servidor : System.Web.Services.WebService
	{
		private ServidorBase servidor;
		public Servidor ()
		{
			servidor = new ServidorBase();
		}
		
		[WebMethod]
		public int Suma(int a, int b)
		{
			return servidor.Suma(a, b);
		}
		
		[WebMethod]
		public int Multiplicacion(int a, int b)
		{
			return servidor.Multiplicacion(a, b);
		}
		
		[WebMethod]
		public Person FindByName(string name)
		{
			Person person = new Person {
				Name = "Mario Chavez",
				Address = "Conocida"
			};
			
			return person;
		}
		
		[WebMethod]
		public Person[] FindAllPeople()
		{
			return new[0];
		}
	}
	
	[Serializable]
	public class Person
	{
		public string Name { get; set; }
		
		[NonSerialized]
		private string address;
		public string Address { get { return address;} set{address=value;} }
	}
	
	public class ServidorBase
	{
		public int Suma(int a, int b)
		{
			return a + b;
		}
		
		public int Multiplicacion(int a, int b)
		{
			return a * b;
		}
	}
}

