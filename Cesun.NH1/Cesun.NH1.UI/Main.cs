using System;
using System.Collections.Generic;
using Cesun.NH1.Data.Domain;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Cesun.NH1.Data;

namespace Cesun.NH1.UI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SessionManager.DomainAssembly = (typeof(Product).Assembly);
			
			Console.WriteLine("Crear esquema de DB? S/N");
			string ret = Console.ReadLine();
			if(ret.ToUpper() == "S")
				new SchemaExport(SessionManager.Configuration())
					.Execute(true, true, false);
				//new SchemaUpdate(cfg).Execute();
			
			IRepository<Product> repository = new ProductRepository(SessionManager.Session());
			
			Product product = new Product() { 
					Name = "MacBook Pro", 
					//Category = "Computer",∂
					Price = 1700m,
					Description = "Aluminum MBP"};
			
				repository.Save(product);
			
			//Product productDB = session.Get<Product>(1);
			
			//TotalProduct Name, TotalUnits, TotalAmount
			
			// Ejemplo con NHibernate donde se use projections
			
			// http://blogs.hibernatingrhinos.com/
				
			IList<Product> products = repository.FindByProperty("Name", "MacBook Pro");
			
			Console.WriteLine(String.Format("Name = {0}, Price = {1}", 
			                                products[0].Name, products[0].Price));
			SessionManager.Close();
		}
	}
}

