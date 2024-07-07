
using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.Events
{
	public class UserTopicEvent
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public eEventTopicType OperationType { get; set; }
		[JsonIgnore]
		public bool Active { get; set; }
		[JsonIgnore]
		public string Event { get; set; }

		public UserTopicEvent(string name, eEventTopicType operationType)
		{
			Id = Guid.NewGuid();
			Name = name;
			OperationType = operationType;
			Event = operationType switch
			{
				eEventTopicType.Created => "new.user",
				eEventTopicType.Updated => "edit.user",
				eEventTopicType.Desactive => "edit.*",
				_ => "new.created",
			};


		}
	}
}
