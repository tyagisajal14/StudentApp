using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp_Models
{
    public class StudentDetailsDto
    {
        public long ResultId { get; set; }
        public long? StudentId { get; set; }
        public string SubjectName { get; set; }
        public int? Marks { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Class { get; set; }
    }
}
