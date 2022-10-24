using DemoArquitectura.Business.Interfaces.SchoolControl;
using DemoArquitectura.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoArquitectura.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSchoolControlController : ControllerBase
    {
        private readonly IStudentBusiness studentBusiness;

        public ApiSchoolControlController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IEnumerable<StudentEntity>> GetAllStudentsAsync()
        {
            var students = await studentBusiness.GetAllAsync();
            return students;
        }

        [HttpPost("AddStudent")]
        public async Task<StudentEntity> AddStudentAsync(StudentEntity studentEntity)
        {
            var sudent = await studentBusiness.AddStudentAsync(studentEntity);
            return sudent;
        }

        [HttpPost("UpdateStudent")]
        public async Task<StudentEntity> UpdateStudentAsync(StudentEntity studentEntity)
        {
            var sudent = await studentBusiness.UpdateStudentAsync(studentEntity);
            return studentEntity;
        }
    }
}
