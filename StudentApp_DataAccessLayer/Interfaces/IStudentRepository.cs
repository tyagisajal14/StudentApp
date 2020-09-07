using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp_DataAccessLayer.Interfaces
{
    public interface IStudentRepository
    {
        Students AddStudent(Students Student);
        bool UpdateStudent(Students Student);
        bool DeleteStudent(string StudentId);
        List<Students> GetAllStudents();
        Students GetStudentById(string StudentId);

    }
}
