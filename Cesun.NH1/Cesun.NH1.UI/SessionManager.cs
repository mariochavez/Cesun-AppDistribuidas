using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace Cesun.NH1.UI
{
	public class SessionManager
	{
		public SessionManager ()
		{
		}
		
		private static ISession session = null;
		private static Configuration configuration = null;
		private static ISessionFactory sessionFactory = null;
		
		public static ISession Session() {
			if(session == null)
				CreateSession();
			return session;
		}
		
		public static Configuration Configuration() {
			if(configuration == null)
				CreateConfiguration();
			
			return configuration;
		}
		
		public static void Close() {
			if(session != null)
				session.Close();
		}
		
		private static void CreateSession() {
			CreateConfiguration();
			sessionFactory = configuration.BuildSessionFactory();
			session = sessionFactory.OpenSession();
		}
		
		private static void CreateConfiguration() {
			if(DomainAssembly == null)
				throw new NullReferenceException("El ensamblado no esta definido");
			
			configuration = new Configuration();
			configuration.Configure();
			configuration.AddAssembly(DomainAssembly);
		}
		
		private static Assembly assembly;
		public static Assembly DomainAssembly { 
			get { return assembly; } 
			set { assembly = value; }
		}
	}
}