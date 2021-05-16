using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Meet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        public readonly IMeetService _meetService;
        public MeetController(IMeetService meetService)
        {
            _meetService = meetService;
        }

        [HttpPost("MeetAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddMeet(MeetAddDTO meetAddDTO)
        {
            var result = await _meetService.AddMeet(meetAddDTO);
            return result > 0 ? StatusCode(StatusCodes.Status201Created) : BadRequest();
        }
    }
}
