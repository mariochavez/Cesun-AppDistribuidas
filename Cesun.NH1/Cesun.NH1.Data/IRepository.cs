using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Criterion;

using Cesun.NH1.Data.Domain;

namespace Cesun.NH1.Data
{
	public interface IRepository<T>
	{
		T Get(int id);
		T[] FindByProperty(string propertyName, object value);
		
		void Save(T model);
	}
	
	public abstract class RepositoryBase<T> : IRepository<T> where T: Entity
	{
		protected ISession session;	
		public RepositoryBase(ISession session)
		{
			this.session = session;
		}
		
		public T Get(int id)
		{
			return session.Get<T>(id);
		}
		
		//public abstract T[] FindByProperty(string propertyName, object value);
		
		public virtual T[] FindByProperty(string propertyName, object value)
		{
			IList<T> list =  session.CreateCriteria<T>()
				.Add(Restrictions.Eq(propertyName, value))
				.List<T>();
						
			return list.ToArray();
		}
		
		public void Save(T model)
		{
			using(ITransaction transaction = session.BeginTransaction())
			{
				try {
					session.Save(model);
					transaction.Commit();
				}
				catch(Exception ex)
				{
					transaction.Rollback();
				}
			}
			
		}
	}
	
	public class Repository<T> : RepositoryBase<T> where T:Entity
	{
		public Repository (ISession session) :base(session)
		{
		}
		
		public override T[] FindByProperty(string propertyName, object value)
		{
			IList<T> list =  session.CreateCriteria<T>()
				.Add(Restrictions.Eq(propertyName, value))
				.List<T>();
						
			return list.ToArray();
		}
	}
	
	public class ProductRepository: Repository<Product>
	{
		public ProductRepository (ISession session) :base(session)
		{
		}
		
		public Product[] FindByPrice(decimal price)
		{
			var list = session.CreateCriteria<Product>()
				.Add(Restrictions.Ge("Price", price))
				.AddOrder(Order.Desc("Price"))
				.List<Product>();
			
			return list.ToArray();
		}
	}
}

