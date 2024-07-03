
namespace Core.Events
{
	public class UserEvent
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UserEvent(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
