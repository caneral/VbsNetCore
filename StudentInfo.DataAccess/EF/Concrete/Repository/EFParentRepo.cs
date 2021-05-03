using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.Parent;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFParentRepo : EFBaseRepo<Parent>, IParentRepo
    {

        public EFParentRepo(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ParentListDTO>> ParentList()
        {
            return await GetListQueryable(p => !p.IsDeleted, p => p.Students)
                .Select(p => new ParentListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    StudentName = p.Students.Select(p => p.Name).Single(),
                    StudentSurname = p.Students.Select(p => p.Surname).Single(),

                }).ToListAsync();    
        }

        public async Task UpdateParent(int id, ParentUpdateDTO parentUpdateDTO)
        {
            var currentParent = await GetByIdAsync(id);
            Update(currentParent);
            currentParent.Name = parentUpdateDTO.Name;
            currentParent.Surname = parentUpdateDTO.Surname;
            currentParent.ModifiedDate = DateTime.Now;
        }
    }
}
