
using Core.Enums;
using Core.Records;
using System.Text.Json.Serialization;

namespace Core.Events
{
	public class UserDirectEvent
	{
        public Guid Id { get; set; }
        public eEventDirectType EventDirectType { private get; set; }
        [JsonIgnore]
        public TypeRecord Type { get; private set; }
        public string Name { get; set; } = null!;

        public UserDirectEvent(string name, eEventDirectType eventDirectType)
        {
            Id = Guid.NewGuid();
			EventDirectType = eventDirectType;
            Type = new TypeRecord((int)eventDirectType, eventDirectType.ToString());
            Name = name;
        }
    }
}
