using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp_Services.Interfaces
{
    public interface IStudentResultService
    {
        bool AddStudentResult(StudentResults Student);
        bool UpdateStudentResult(StudentResults Student);
        bool DeleteStudentResult(string StudentResultId);
        List<StudentDetails> GetStudentsResultByStuId(string StudentId);
        StudentResults GetStudentResultByResultId(string resultId);
    }
}
