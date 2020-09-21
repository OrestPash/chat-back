using System.Threading.Tasks;
using Chat.API.Models.HubConfig;
using Chat.API.Models.Message;
using Chat.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;
        private readonly IHubContext<MessageHub> _hub;

        public MessagesController(IMessagesService messagesService, IHubContext<MessageHub> hub)
        {
            _messagesService = messagesService;
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int take, int skip)
        {
            var result = await _messagesService.GetAllAsync(take, skip);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMessageVM model)
        {
            var message = await _messagesService.CreateAsync(model);

            await _hub.Clients.All.SendAsync("CreateOne", message);

            return Ok(new { message.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMessageVM model)
        {
            var message = await _messagesService.UpdateAsync(id, model);

            if (message != null)
            {
                await _hub.Clients.All.SendAsync("UpdateOne", message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messagesService.DeleteAsync(id);

            if (message != null)
            {
                await _hub.Clients.All.SendAsync("DeleteOne", message);
            }

            return NoContent();
        }
    }
}