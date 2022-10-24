using DemoArquitectura.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoArquitectura.Business.Interfaces.SchoolControl
{
    public interface IStudentBusiness
    {
        Task<StudentEntity> AddStudentAsync(StudentEntity studentEntity);
        Task<IEnumerable<StudentEntity>> GetAllAsync();
        Task<StudentEntity> UpdateStudentAsync(StudentEntity studentEntity);
    }
}
