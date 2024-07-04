
using Core.Enums;

namespace Core.Events
{
	public class UserDirectEvent
	{
        public Guid Id { get; set; }
        public eEventDirectType Type { get; set; }
        public string Name { get; set; } = null!;

        public UserDirectEvent(string name, eEventDirectType type)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
        }
    }
}
