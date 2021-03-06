using ApplicationCore.Utility.Mapper;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Class;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Meet;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class MeetService : IMeetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }  

        public async Task<int> AddMeet(MeetAddDTO meetAddDTO)
        {
            var newMeet = _mapper.Map<MeetAddDTO, Meet>(meetAddDTO);
            await _unitOfWork.Meets.AddAsync(newMeet);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<MeetDTO> GetMeetById(int studentId)
        {
            var tc = _unitOfWork.AppUsers.GetAsync(p => p.Id == studentId);
            var user = _unitOfWork.Students.GetAsync(p => p.TCNumber == tc.Result.TCNumber);
            return await _unitOfWork.Meets.GetMeetById(user.Result.Id);
        }

        public async Task<List<MeetListDTO>> GetMeetList()
        {
            return await _unitOfWork.Meets.GetMeetList();
        } 

        public async Task<int> UpdateMeetAsync(int id)
        {
            _unitOfWork.Meets.UpdateMeet(id);
            return await _unitOfWork.SaveAsync();

        }
    }
}
