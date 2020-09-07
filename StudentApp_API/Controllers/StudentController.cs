using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp_DataAccessLayer.Models;
using StudentApp_Models;
using StudentApp_Services.Interfaces;

namespace StudentApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IMapper _mapper;
        IStudentService _service;
        public StudentController(IMapper mapper, IStudentService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [EnableCors()]
        [HttpGet]
        [Route("getallstudents")]
        public IEnumerable<StudentDto> GetAllStudents()
        {
            try
            {
                List<StudentDto> students = new List<StudentDto>();
                var studentlst = _service.GetAllStudents();
                foreach (var student in studentlst)
                {
                    students.Add(_mapper.Map<Students, StudentDto>(student));
                }
                if (students.Count > 0)
                {
                    return students;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        [EnableCors()]
        [HttpGet]
        [Route("getstudentbyid")]
        public IEnumerable<StudentDto> GetStudentById(string studentId)
        {
            try
            {
                List<StudentDto> students = new List<StudentDto>();
                var studentlst = _service.GetStudentById(studentId);
               students.Add(_mapper.Map<Students, StudentDto>(studentlst));
                if (students.Count > 0)
                {
                    return students;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        [EnableCors()]
        [HttpPost]
        [Route("savestudent")]
        public IEnumerable<Students> SaveStudent(string firstname, string lastname, string standard)
        {
            try
            {
                List<Students> record = new List<Students>();
                StudentDto student = new StudentDto();
                student.FirstName = firstname;
                student.LastName = lastname;
                student.Class = standard;
                var result = _service.AddStudent(_mapper.Map<StudentDto, Students>(student));
                record.Add(result);
                return record;
            }
            catch (Exception e)
            {

                return null;
            }

        }
        [EnableCors()]
        [HttpPut]
        [Route("updatestudent")]
        public void UpdateStudent(long studentid, string firstname, string lastname, string standard)
        {
            try
            {
                StudentDto student = new StudentDto();
                student.StudentId = studentid;
                student.FirstName = firstname;
                student.LastName = lastname;
                student.Class = standard;
                bool result = _service.UpdateStudent(_mapper.Map<StudentDto, Students>(student));
                //return result;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        [EnableCors()]
        [HttpDelete]
        [Route("deletestudent")]
        public void DeleteStudent(string studentid)
        {
            try
            {
                List<bool> record = new List<bool>();
                bool result = _service.DeleteStudent(studentid);
                record.Add(result);
                //return record;
            }
            catch (Exception e)
            {

                //return null;
                throw;
            }

        }
    }
}
