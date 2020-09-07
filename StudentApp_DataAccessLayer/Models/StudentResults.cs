using System;
using System.Collections.Generic;

namespace StudentApp_DataAccessLayer.Models
{
    public partial class StudentResults
    {
        public long ResultId { get; set; }
        public long? StudentId { get; set; }
        public string SubjectName { get; set; }
        public int? Marks { get; set; }

        public virtual Students Student { get; set; }
    }
}
