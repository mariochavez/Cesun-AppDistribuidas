using System;
using Cesun.Consultas;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace Cesun.UI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			XmlConfigurationSource config = new XmlConfigurationSource("arconfig.xml");
			ActiveRecordStarter.Initialize(config, 
			                               typeof(User),
			                               typeof(Question));
			
			Console.WriteLine("Deseas crear la DB? (Y/N): (Y)es");
			string response = Console.ReadLine();
			
			if(response == "Y") {
				ActiveRecordStarter.CreateSchema();
				InsertInfo();
				
				//InsertInvalidInfo();
			}
			
			QueryInfo();
		}
		
		public static void InsertInvalidInfo() 
		{
			Console.WriteLine("Insertando informacion invalida");
			User user = new User();
			//user.Username = "mario.chavez";
			user.Email = "mario.chavez@gmail.com";
			
			user.SaveAndFlush();
		}
		
		public static void InsertInfo() 
		{
			User user = new User();
			user.Username = "mario.chavez";
			user.Email = "mario.chavez@gmail.com";
			user.SaveAndFlush();
			
			Question q1 = new Question();
			q1.Message = "Pregunta 1";
			q1.User = user;
			
			Question q2 = new Question();
			q2.Message = "Pregunta 2";
			q2.User = user;
			
			q1.Save();
			q2.Save();
			user.SaveAndFlush();
		}
		
		public static void QueryInfo()
		{
			User user = User.Find(1);
			Console.WriteLine(String.Format("{0} => {1}", 
			                                user.Username, user.Email));
			
			User[] users = User.FindByUsername("mario.chavez");
			if(users.Length > 0)
			{
				user = users[0];
				Console.WriteLine(String.Format("{0} => {1}", 
			                                user.Username, user.Email));
			}
		}
	}
}

