using Core.Interfaces.Publishers;
using Core.Events;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessageController : ControllerBase
	{

		private readonly ILogger<MessageController> _logger;
		private readonly IPublishEndpointWrapper _messagePublish;
		private readonly IPublishSchedulerWrapper _messageSchedulerPublish;
		public MessageController(ILogger<MessageController> logger, IPublishEndpointWrapper messagePublish, IPublishSchedulerWrapper messageSchedulerPublish)
		{
			_logger = logger;
			_messagePublish = messagePublish;
			_messageSchedulerPublish = messageSchedulerPublish;
		}

		[HttpPost]
		[Route("PublishFanoutUser")]
		public async Task<IActionResult> PublishFanoutUserAsync(UserFanoutEvent user)
		{
			
			await _messagePublish.PublishFanoutAsync(user);
			_logger.LogInformation("Message Published");
			return Ok();
		}

		[HttpPost]
		[Route("PublishDirectUser")]
		public async Task<IActionResult> PublishDirectUserAsync(UserDirectEvent user)
		{

			await _messagePublish.PublishFanoutAsync(user);
			_logger.LogInformation("Message Published");
			return Ok();
		}

		[HttpPost]
		[Route("PublishTopicUser")]
		public async Task<IActionResult> PublishTopicUserAsync(UserTopicEvent user)
		{

			await _messagePublish.PublishFanoutAsync(user);
			_logger.LogInformation("Message Published");
			return Ok();
		}

		[HttpPost]
		[Route("PublishHeadersUser")]
		public async Task<IActionResult> PublishHeadersUserAsync(UserHeadersEvent user)
		{

			await _messagePublish.PublishHeadersAsync(user);
			_logger.LogInformation("Message Published");
			return Ok();
		}

		[HttpPost]
		[Route("PublishSchedulerUser")]
		public async Task<IActionResult> PublishSchedulerUserAsync(UserFanoutEvent user)
		{
			await _messageSchedulerPublish.PublishSchedulerAsync(user);
			_logger.LogInformation("Message Published");
			return Ok();
		}
	}
}
