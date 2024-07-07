using Core.Events;

namespace Core.Interfaces.Publishers
{
	public interface IPublishEndpointWrapper
	{
		public Task PublishFanoutAsync<T>(T message);
		public Task PublishDirectAsync(UserDirectEvent user);
		public Task PublishTopicAsync(UserTopicEvent user);
		public Task PublishHeadersAsync<T>(T message);
	}
}
