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
    public class StudentResultController : ControllerBase
    {
        IMapper _mapper;
        IStudentResultService _service;
        public StudentResultController(IMapper mapper, IStudentResultService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [EnableCors()]
        [HttpGet]
        [Route("getstudentsresultbystuid")]
        public IEnumerable<StudentDetailsDto> GetStudentsResultByStuId(string studentId)
        {
            try
            {
                List<StudentDetailsDto> results = new List<StudentDetailsDto>();
                var resultlst = _service.GetStudentsResultByStuId(studentId);
                foreach (var res in resultlst)
                {
                    results.Add(_mapper.Map<StudentDetails, StudentDetailsDto>(res));
                }
                if (results.Count > 0)
                {
                    return results;
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
        [Route("getstudentsresultbyresultid")]
        public IEnumerable<StudentResultDto> GetStudentsResultByResultId(string resultId)
        {
            try
            {
                List<StudentResultDto> results = new List<StudentResultDto>();
                var resultlst = _service.GetStudentResultByResultId(resultId);
                results.Add(_mapper.Map<StudentResults, StudentResultDto>(resultlst));
                if (results.Count > 0)
                {
                    return results;
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
        [Route("savestudentresult")]
        public bool SaveStudentResult(long studentid,string subjectname, int marks)
        {
            try
            {
                StudentResultDto student = new StudentResultDto();
                student.StudentId = studentid;
                student.SubjectName = subjectname;
                student.Marks = marks;
                bool result = _service.AddStudentResult(_mapper.Map<StudentResultDto, StudentResults>(student));
                return result;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        [EnableCors()]
        [HttpPut]
        [Route("updatestudentresult")]
        public bool UpdateStudentResult(long resultid, long studentid, string subjectName, int marks)
        {
            try
            {
                StudentResultDto student = new StudentResultDto();
                student.ResultId = resultid;
                student.StudentId = studentid;
                student.SubjectName = subjectName;
                student.Marks = marks;
                bool result = _service.UpdateStudentResult(_mapper.Map<StudentResultDto, StudentResults>(student));
                return result;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        [EnableCors()]
        [HttpDelete]
        [Route("deletestudentresult")]
        public bool DeleteStudentResult(string studentresultid)
        {
            try
            {
                bool result = _service.DeleteStudentResult(studentresultid);
                return result;
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }
}
