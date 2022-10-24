using Dapper;
using DemoArquitectura.Data.Interfaces.SchoolControl;
using DemoArquitectura.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DemoArquitectura.Data.Repositories.SchoolControl
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

       

        public async Task<StudentEntity> AddStudentAsync(StudentEntity studentEntity)
        {
            using var connection = new SqlConnection(connectionString);
            var student = await connection.QueryFirstOrDefaultAsync<StudentEntity>(@"
                INSERT INTO Students (StudentName, Address, Age, LastUpdate)
                VALUES (@StudentName, @Address, @Age, @LastUpdate)
                
                SELECT * FROM Students WHERE StudentID = SCOPE_IDENTITY()
", studentEntity);

            return student;
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using var connection = new SqlConnection(connectionString);
            var students = await connection.QueryAsync<StudentEntity>("SELECT * FROM Students");

            return students;
        }

        public async Task<StudentEntity> UpdateStudentAsync(StudentEntity studentEntity)
        {
            using var connection = new SqlConnection(connectionString);
            var student = await connection.QueryFirstOrDefaultAsync<StudentEntity>(@"
                UPDATE Students
                SET StudentName = @StudentName
                WHERE StudentID = @StudentID
        
                SELECT * FROM Students WHERE StudentID = @StudentID
", studentEntity);

            return student;
        }
    }
}
