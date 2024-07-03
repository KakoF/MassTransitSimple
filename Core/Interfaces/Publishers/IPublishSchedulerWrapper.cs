namespace Core.Interfaces.Publishers
{
	public interface IPublishSchedulerWrapper
	{
		public Task PublishSchedulerAsync<T>(T message);
	}
}
