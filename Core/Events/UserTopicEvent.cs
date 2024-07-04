
namespace Core.Events
{
	public class UserTopicEvent
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UserTopicEvent(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
