
namespace Core.Events
{
	public class UserHeadersEvent
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UserHeadersEvent(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
