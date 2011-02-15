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
				
			//IList<Product> products = repository.FindByProperty("Name", "MacBook Pro");
			
			//Console.WriteLine(String.Format("Name = {0}, Price = {1}", 
			//                                products[0].Name, products[0].Price));
			
			
			var projection = Projections.ProjectionList()
				.Add(Projections.Property("Name"), "Nombre")
				.Add(Projections.Property("Price"), "Precio")
				.Add(Projections.Constant(1), "TipoProducto");
					
			var criteria = SessionManager.Session().CreateCriteria<Product>()
				.Add(Expression.Ge("Price", 100m))
				.AddOrder(Order.Asc("Name"));
			
			criteria.SetProjection(Projections.Distinct(projection))
				.SetResultTransformer(
				                      NHibernate.Transform.Transformers.AliasToBean(
				                                                                    typeof(ProductDTO)));
			
			
			IList<ProductDTO> productos = criteria.List<ProductDTO>();
			
			SessionManager.Close();
		}
	}
	
	public class ProductDTO
	{
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public int TipoProducto { get; set; }
	}
}

