using System;
using Castle.ActiveRecord;

namespace Cesun.Consultas
{
	[ActiveRecord(Cache=CacheEnum.ReadWrite)]
	public class Question : ActiveRecordValidationBase<Question>
	{
		public Question ()
		{
		}
		
		[PrimaryKey(PrimaryKeyType.Native)]
		public int Id { get; set; }
		
		[Property]
		public string Message { get; set; }
		
		[BelongsTo("UserId")]
		public User User { get; set; }
	}
}

