using ApplicationCore.Utility.Mapper;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Class;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
       

        public async Task<int> AddClass(ClassAddDTO classAddDTO)
        {
            var newClass = _mapper.Map<ClassAddDTO, Class>(classAddDTO);
            await _unitOfWork.Classes.AddAsync(newClass);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<ClassListDTO>> GetClassList()
        {
            return await _unitOfWork.Classes.GetClassList();
        }
    }
}
