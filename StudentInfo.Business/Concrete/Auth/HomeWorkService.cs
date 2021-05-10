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

        public async Task<List<HomeWorkListDTO>> GetHomeWorkWithClass(string tcNumber)
        {
            var abc = _unitOfWork.Students.GetAsync(p => p.TCNumber == tcNumber);
            return await _unitOfWork.HomeWorks.GetHomeWorkWithClass(abc.Result.ClassId);
        }
    }
}
