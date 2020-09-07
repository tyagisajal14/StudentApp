using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp_DataAccessLayer.Interfaces
{
    public interface IStudentResultRepository
    {
        bool AddStudentResult(StudentResults Student);
        bool UpdateStudentResult(StudentResults Student);
        bool DeleteStudentResult(string StudentResultId);
        List<StudentDetails> GetStudentsResultByStuId(string StudentId);
        StudentResults GetStudentResultByResultId(string resultId);
    }
}
