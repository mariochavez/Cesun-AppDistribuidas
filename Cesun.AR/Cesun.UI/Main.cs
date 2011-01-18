using System;
using Cesun.Consultas;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System.IO;

namespace Cesun.UI
{
	class MainClass
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainClass));
		
		public static void Initialize()
		{
			FileInfo fileInfo = new FileInfo("log4net.xml");
			log4net.Config.XmlConfigurator.Configure(fileInfo);

			log.Info("Inicializando app");
			
			XmlConfigurationSource arConfig = new XmlConfigurationSource("arconfig.xml");
			ActiveRecordStarter.Initialize(arConfig, 
			                               typeof(User),
			                               typeof(Question));
		}
		
		public static void Main (string[] args)
		{
			Initialize();
			
			Console.WriteLine("Deseas crear la DB? (Y/N): (Y)es");
			string response = Console.ReadLine();
			
			if(response == "Y") {
				ActiveRecordStarter.CreateSchema();
				InsertInfo();
				
				InsertInvalidInfo();
			}
			
			QueryInfo();
			QueryInfo();
		}
		
		public static void InsertInvalidInfo() 
		{
			log.Info("Insertando informacion invalida");
			User user = new User();
			//user.Username = "mario.chavez";
			user.Email = "mario.chavez@gmail.com";
			
			if(!user.IsValid()) {
				foreach (var error in user.ValidationErrorMessages) {
					log.Error(String.Format("Error: {0}", error));
				}
			}
			
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
			
			user = User.Find(1);
			Console.WriteLine(String.Format("{0} => {1}", 
			                                user.Username, user.Email));
		}
	}
}

