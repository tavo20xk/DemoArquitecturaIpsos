using System;
using System.Collections.Generic;
using System.Text;

namespace DemoArquitectura.Models.Entities
{
    public class StudentEntity
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int Age { get; set;  }
        public DateTime LastUpdate { get; set; }
    }
}
