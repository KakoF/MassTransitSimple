namespace Core.Interfaces.Publishers
{
	public interface IPublishEndpointWrapper
	{
		public Task PublishFanoutAsync<T>(T message);
		public Task PublishDirectAsync<T>(T message);
		public Task PublishTopicAsync<T>(T message);
		public Task PublishHeadersAsync<T>(T message);
	}
}
