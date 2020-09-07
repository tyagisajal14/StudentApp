using StudentApp_DataAccessLayer.Interfaces;
using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentApp_DataAccessLayer.Repository
{
    public class StudentResultRepository : IStudentResultRepository
    {
        StudentDatabaseContext _context;
        public StudentResultRepository(StudentDatabaseContext context)
        {
            _context = context;
        }
        public bool AddStudentResult(StudentResults Student)
        {
            StudentResults stud = new StudentResults();
            //var studentId = _context.Students.Select(x => x.StudentId).DefaultIfEmpty().Max();
            try
            {
                stud.StudentId = Student.StudentId;
                stud.SubjectName = Student.SubjectName;
                stud.Marks = Student.Marks;
                _context.StudentResults.Add(stud);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteStudentResult(string StudentResultId)
        {
            try
            {
                var stud = (from stu in _context.StudentResults
                            where stu.ResultId.ToString() == StudentResultId
                            select stu).FirstOrDefault();
                _context.StudentResults.Remove(stud);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public StudentResults GetStudentResultByResultId(string resultId)
        {
            try
            {
                var student = (from stu in _context.StudentResults
                               where stu.ResultId.ToString() == resultId
                               select stu).FirstOrDefault();
                return student;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<StudentDetails> GetStudentsResultByStuId(string StudentId)
        {
            try
            {
                var student = (from stures in _context.StudentResults
                               join stu in _context.Students
                               on stures.StudentId equals stu.StudentId
                               where stures.StudentId.ToString() == StudentId
                               select new StudentDetails
                               {
                                   ResultId=stures.ResultId,
                                   StudentId=stu.StudentId,
                                   FirstName=stu.FirstName,
                                   LastName=stu.LastName,
                                   Class=stu.Class,
                                   SubjectName=stures.SubjectName,
                                   Marks=stures.Marks
                               }).ToList();    
                return student;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool UpdateStudentResult(StudentResults Student)
        {
            try
            {
                var student = (from stu in _context.StudentResults
                               where stu.StudentId == Student.StudentId
                               select stu).FirstOrDefault();
                student.SubjectName = Student.SubjectName;
                student.Marks = Student.Marks;
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
