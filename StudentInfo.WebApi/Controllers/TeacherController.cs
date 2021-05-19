using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Teacher;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("TeacherAdd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddTeacher(TeacherAddDTO teacherAddDTO)
        {
            var result = await _teacherService.AddTeacher(teacherAddDTO);
            return result > 0 ? StatusCode(StatusCodes.Status201Created) : BadRequest();
        }

        

    }
}
