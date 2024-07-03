using Core.Interfaces.Publishers;
using Core.Events;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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
			_messagePublish = messagePublish;
			_messageSchedulerPublish = messageSchedulerPublish;
		}

		[HttpPost]
		[Route("PublishUser")]
		public async Task<IActionResult> PostUserAsync(UserEvent user)
		{
			await _messagePublish.PublishAsync(user);
			return Ok();
		}

		[HttpPost]
		[Route("PublishSchedulerUser")]
		public async Task<IActionResult> PostSchedulerUserAsync(UserEvent user)
		{
			await _messageSchedulerPublish.PublishSchedulerAsync(user);
			return Ok();
		}
	}
}
