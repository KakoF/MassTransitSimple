
namespace Core.Events
{
	public class UserFanoutEvent
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UserFanoutEvent(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
