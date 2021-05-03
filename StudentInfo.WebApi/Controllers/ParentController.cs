using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Parent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet("ParentList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ParentListDTO>>> ListParent()
        {
            return Ok(await _parentService.ParentList());
        }

        [HttpPost("ParentAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddParent(ParentAddDTO parentAddDTO)
        {
            var result = await _parentService.AddParent(parentAddDTO);
            return result > 0 ? StatusCode(StatusCodes.Status201Created) : BadRequest();
        }

        [HttpPut("UpdateParent/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UpdateParent(int id, [FromBody] ParentUpdateDTO parentUpdateDTO)
        {
            var result = await _parentService.UpdateParent(id, parentUpdateDTO);
            return result > 0 ? StatusCode(StatusCodes.Status200OK) : BadRequest();
        }
        [HttpDelete("DeleteParent/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeletePerson(int id)
        {
            _parentService.DeleteParent(id);
            return Ok();
        }
    }
}
