using System;
namespace Fiorello_API.Models
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
	}
}

