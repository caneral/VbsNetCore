using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpPost("MessageAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddMessage(MessageAddDTO messageAddDTO)
        {
            var result = await _messageService.AddMessage(messageAddDTO);
            return result > 0 ? StatusCode(StatusCodes.Status201Created) : BadRequest();
        }
        //[Authorize(Roles = "Admin,Teacher")]
        [HttpGet("GetMessageList/{studentId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MessageListDTO>>> GetMessageList(int? studentId)
        {
            return Ok(await _messageService.GetMessageList(studentId));
        }

        [HttpGet("MessageListWithClass/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<string>> ListHomeWorkWithClass(int userId)
        {
            var result = await _messageService.GetMessageWithClass(userId);
            return Ok(result);
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> DeleteMessage(int id)
        {
            return Ok(await _messageService.DeleteMessage(id));
        }

        [HttpPut("UpdateMessage/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UpdateMessage(int id, MessageUpdateDTO messageUpdateDTO)
        {
            var result = await _messageService.UpdateMessage(id, messageUpdateDTO);
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return BadRequest();
        }
        [HttpGet("GetTotalMessageCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetTotalMessageCount()
        {
            var result = await _messageService.GetTotalMessageCount();
            return Ok(result);
        }
    }
}
