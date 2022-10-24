using DemoArquitectura.Business.Interfaces.SchoolControl;
using DemoArquitectura.Data.Interfaces.SchoolControl;
using DemoArquitectura.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoArquitectura.Business.SchoolControl
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            var students = await studentRepository.GetAllAsync();
            return students;
        }

        public async Task<StudentEntity> AddStudentAsync(StudentEntity studentEntity)
        {
            studentEntity.LastUpdate = DateTime.Now;

            var student = await studentRepository.AddStudentAsync(studentEntity);
            return student;
        }

        public async Task<StudentEntity> UpdateStudentAsync(StudentEntity studentEntity)
        {
            studentEntity.LastUpdate = DateTime.Now;

            var student = await studentRepository.UpdateStudentAsync(studentEntity);
            return student;
        }
    }
}
