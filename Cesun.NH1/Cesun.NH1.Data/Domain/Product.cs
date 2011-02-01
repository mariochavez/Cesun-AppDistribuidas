using System;
namespace Cesun.NH1.Data.Domain
{
	public class Product
	{
		public Product ()
		{
		}
		
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Category { get; set; }
		public virtual decimal Price { get; set; }
		public virtual string Description { get; set; }
	}
}

