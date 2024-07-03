namespace Core.Interfaces.Publishers
{
	public interface IPublishEndpointWrapper
	{
		public Task PublishAsync<T>(T message);
	}
}
