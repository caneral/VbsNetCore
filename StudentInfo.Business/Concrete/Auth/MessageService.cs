﻿using ApplicationCore.Utility.Mapper;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Message;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Genel mesaj ise studentId null olarak gelsin
        /// </summary>
        public async Task<int> AddMessage(MessageAddDTO messageAddDTO)
        {
            var message = _mapper.Map<MessageAddDTO, Message>(messageAddDTO);
            await _unitOfWork.Messages.AddAsync(message);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteMessage(int id)
        {
            _unitOfWork.Messages.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<MessageListDTO>> GetMessageList(int? studentId)
        {
            return await _unitOfWork.Messages.GetMessageList(studentId);
        }

        public Task<int> UpdateMessage(int id, MessageUpdateDTO messageUpdate)
        {
           _unitOfWork.Messages.UpdateMessage(id, messageUpdate);
            return _unitOfWork.SaveAsync();
        }
    }
}
