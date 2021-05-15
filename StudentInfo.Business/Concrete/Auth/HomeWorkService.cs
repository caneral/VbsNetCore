using ApplicationCore.Utility.Mapper;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class HomeWorkService : IHomeWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeWorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddHomeWork(HomeWorkAddDTO homeWorkAddDTO)
        {
            var homework = _mapper.Map<HomeWorkAddDTO, HomeWork>(homeWorkAddDTO);
            await _unitOfWork.HomeWorks.AddAsync(homework);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<HomeWorkListDTO>> GetHomeWorkList()
        {
            return await _unitOfWork.HomeWorks.GetHomeWorkList();

        }

        public async Task<List<HomeWorkListDTO>> GetHomeWorkWithClass(int userId)
        {
            var tc = _unitOfWork.AppUsers.GetAsync(p => p.Id == userId); 
            var userClass = _unitOfWork.Students.GetAsync(p => p.TCNumber == tc.Result.TCNumber);
            return await _unitOfWork.HomeWorks.GetHomeWorkWithClass(userClass.Result.ClassId);
        }

        public Task<int> GetTotalHomeWorkCount()
        {
            return _unitOfWork.HomeWorks.GetTotalHomeWorkCount();
        }

        public async Task<List<HomeWorkListDTO>> GetLastAdded5HomeWorks()
        {
            return await _unitOfWork.HomeWorks.GetLastAdded5HomeWorks();
        }
        public async Task<List<HomeWorkListDTO>> GetLastAddedHomeWork()
        {
            return await _unitOfWork.HomeWorks.GetLastAddedHomeWork();
        }
        public async Task<int> UpdateHomeWorkFile(int odevId, string homeWorkFileId)
        {
            var homeworkObject = await _unitOfWork.HomeWorks.GetByIdAsync(odevId);
            if (homeworkObject == null)
            {
                return await Task.FromResult(-1);
            }

            homeworkObject.FileId = homeWorkFileId;
            _unitOfWork.HomeWorks.Update(homeworkObject);
            return await _unitOfWork.SaveAsync();
        }
        public async Task<string> GetHomeworkFile(int odevId)
        {
            var homeworkFileId = await _unitOfWork.HomeWorks.GetQueryable(p => !p.IsDeleted && p.Id == odevId)
                .Select(p => p.FileId)
                .SingleOrDefaultAsync();

            if (string.IsNullOrWhiteSpace(homeworkFileId))
            {
                return await Task.FromResult("-1");
            }

            return homeworkFileId;
        }
    }
}
