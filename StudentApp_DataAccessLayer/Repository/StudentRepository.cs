using StudentApp_DataAccessLayer.Interfaces;
using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentApp_DataAccessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentDatabaseContext _context;
        public StudentRepository(StudentDatabaseContext context)
        {
            _context = context;
        }
        public Students AddStudent(Students Student)
        {
            Students stud = new Students();
            //var studentId = 1;
            var studentId = _context.Students.Select(x => x.StudentId).DefaultIfEmpty().Max();
            try
            {
                stud.StudentId = studentId + 1;
                stud.FirstName = Student.FirstName;
                stud.LastName = Student.LastName;
                stud.Class = Student.Class;
                _context.Students.Add(stud);
                _context.SaveChanges();
                return stud;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool DeleteStudent(string StudentId)
        {
            try
            {
                var stud = (from stu in _context.Students
                            where stu.StudentId.ToString() == StudentId
                            select stu).FirstOrDefault();
                var studResults = (from stRes in _context.StudentResults
                                   where stRes.StudentId.ToString() == StudentId
                                   select stRes).ToList();
                foreach (var currentStudent in studResults)
                {
                    _context.StudentResults.Remove(currentStudent);
                }
                _context.Students.Remove(stud);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Students> GetAllStudents()
        {
            try
            {
                var studentList = (from student in _context.Students
                                   select student).ToList();
                return studentList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Students GetStudentById(string StudentId)
        {
            try
            {
                var student = (from stu in _context.Students
                               where stu.StudentId.ToString() == StudentId
                               select stu).FirstOrDefault();
                return student;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool UpdateStudent(Students Student)
        {
            try
            {
                var student = (from stu in _context.Students
                               where stu.StudentId == Student.StudentId
                               select stu).FirstOrDefault();
                student.Class = Student.Class;
                student.FirstName = Student.FirstName;
                student.LastName = Student.LastName;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
