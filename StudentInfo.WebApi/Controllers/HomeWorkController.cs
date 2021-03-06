using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.MongoDB;
using StudentInfo.Entity.DTO.HomeWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        public readonly IHomeWorkService _homeWorkService;
        public readonly MongoDbContext _mongoDbContext;



        public HomeWorkController(IHomeWorkService homeWorkService, MongoDbContext mongoDbContext)
        {
            _homeWorkService = homeWorkService;
            _mongoDbContext = mongoDbContext;

        }

        [HttpPost("HomeWorkAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddHomeWork(HomeWorkAddDTO homeWorkAddDTO)
        {
            var result = await _homeWorkService.AddHomeWork(homeWorkAddDTO);
            int lastAddedId = 0;
            if (result > 0)
            {
                var abc = await _homeWorkService.GetLastAddedHomeWork();
                lastAddedId = abc[0].Id;
            }
            return result > 0 ? Ok(lastAddedId) : BadRequest();
        }

        [HttpPost("HomeWorkFileAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddHomeWorkFile(int odevId,IFormFile file)
        {
            var homeWorkCollection = _mongoDbContext.GetCollection<HomeWorkFiles>();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var homeWorkFile = new HomeWorkFiles()
                {
                    Id = ObjectId.GenerateNewId(),
                    Content = memoryStream.ToArray()

                };
                homeWorkCollection.InsertOne(homeWorkFile);
                var hFile = await _homeWorkService.UpdateHomeWorkFile(odevId, homeWorkFile.Id.ToString());
                if (hFile == -1)
                {
                    return Ok(new { code = StatusCode(1001), type = "error" });
                }

            }
            return Ok("Yükleme başarılı");
        }

        [HttpGet("GetHomeworkFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetHomeworkFile(int odevId)
        {
            var list = new List<string>();
            var homeworkFileId = await _homeWorkService.GetHomeworkFile(odevId);

            var homeworkCollection = _mongoDbContext.GetCollection<HomeWorkFiles>();
            var homeworkFile = await homeworkCollection.Find(p => p.Id == ObjectId.Parse(homeworkFileId)).FirstOrDefaultAsync();


            return File(homeworkFile.Content, "image/jpg");
        }
        /// <summary>
        /// Ödevleri Listele
        /// </summary>
        /// <returns></returns>
        [HttpGet("HomeWorkList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> ListHomeWork( )
        {
            var result = await _homeWorkService.GetHomeWorkList();
            return Ok(result);
        }
        /// <summary>
        /// Kullanıcı id ye göre ödev getir
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("HomeWorkListWithClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<string>> ListHomeWorkWithClass(int userId)
        {
            var result = await _homeWorkService.GetHomeWorkWithClass(userId);
            return Ok(result);
        }

        [HttpGet("GetTotalHomeWorkCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetTotalHomeWorkCount()
        {
            var result = await _homeWorkService.GetTotalHomeWorkCount();
            return Ok(result);
        }

        [HttpGet("GetLastAdded5HomeWorks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetLastAdded5HomeWorks()
        {
            var result = await _homeWorkService.GetLastAdded5HomeWorks();
            return Ok(result);
        }

        [HttpGet("GetLastAddedHomeWork")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetLastAddedHomeWork()
        {
            var result = await _homeWorkService.GetLastAddedHomeWork();
            return Ok(result);
        }
    }
}
