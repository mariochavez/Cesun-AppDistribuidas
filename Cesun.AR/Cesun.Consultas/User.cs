using System;
using System.Collections.Generic;
using Castle.ActiveRecord;
using Castle.Components.Validator;

namespace Cesun.Consultas
{
	[ActiveRecord(Cache=CacheEnum.ReadWrite)]
	public class User : ActiveRecordValidationBase<User>
	{
		private IList<Question> questions = new List<Question>();
		
		public User ()
		{
		}
		
		[PrimaryKey(PrimaryKeyType.Native)]
		public int Id  { get; set; }
		
		[Property]
		[ValidateNonEmpty("No debe de estar vacio")]
		public string Username { get; set; }
		
		[Property]
		public string Email { get; set; }
		
		[HasMany]
		public IList<Question> Questions
		{
			get { return questions; }
			set { questions = value; }
		}
		
		public  static User[] FindByUsername(string username)
		{
			return User.FindAllByProperty("Username", username);
		}
	}
}

