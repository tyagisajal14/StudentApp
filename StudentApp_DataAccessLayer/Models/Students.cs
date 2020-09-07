using System;
using System.Collections.Generic;

namespace StudentApp_DataAccessLayer.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentResults = new HashSet<StudentResults>();
        }

        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public virtual ICollection<StudentResults> StudentResults { get; set; }
    }
}
