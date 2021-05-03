using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Authentication;
using System;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/api/v1/register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> AddPersonAsync([FromBody] UserRegisterDTO userRegisterDto)
        {
            try
            {
                var result = _authService.Register(userRegisterDto);
                if (result != null)
                {

                    return StatusCode(StatusCodes.Status201Created);
                }
            }
            catch (Exception)
            {

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/api/v1/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login(AppUserLoginDTO apUserLoginDTO)
        {
            try
            {
                var appUser = await _authService.Login(apUserLoginDTO);
                if (appUser == null)
                {
                    return Unauthorized("Kullanıcı adı veya şifre geçerli değil.");
                }

                var accessToken = await _authService.CreateAccessToken(appUser);
                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
