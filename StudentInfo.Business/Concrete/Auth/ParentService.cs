using ApplicationCore.Utility.Mapper;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Parent;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddParent(ParentAddDTO parentAddDTO)
        {
            var parent = _mapper.Map<ParentAddDTO, Parent>(parentAddDTO);
            await _unitOfWork.Parents.AddAsync(parent);
            return await _unitOfWork.SaveAsync();
        }

        public void DeleteParent(int id)
        {
            _unitOfWork.Parents.Delete(id);
            _unitOfWork.Save();
        }

        public async Task<List<ParentListDTO>> ParentList()
        {
            return await _unitOfWork.Parents.ParentList();
        }

        public Task<int> UpdateParent(int id, ParentUpdateDTO parentUpdateDTO)
        {
            _unitOfWork.Parents.UpdateParent(id, parentUpdateDTO);
            return _unitOfWork.SaveAsync();
        }
    }
}
