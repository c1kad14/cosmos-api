using Domain.Interfaces;

namespace Domain.Base
{
    public abstract class BaseConfigEntity : IBaseEntity
    {
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
