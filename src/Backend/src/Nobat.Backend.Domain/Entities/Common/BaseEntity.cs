using System.ComponentModel.DataAnnotations;

namespace Nobat.Backend.Domain.Entities.Common
{
	public interface IEntity
	{
	}

	public abstract class BaseEntity<TKey> : IEntity
	{
		[Key]
		public TKey Id { get; set; }

		public DateTime CreateAt { get; set; } = DateTime.UtcNow;

		public DateTime? UpdateAt { get; set; }

		public bool IsDeleted { get; set; } = false;

		public DateTime? DeletedAt { get; set; }
	}

	public class BaseEntity : BaseEntity<int>
	{
	}
}
