using AutoMapper;
using Diary.Services.Abstract;
using Diary.Services.Models;
using Diary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        /// <summary>
        /// student controller
        /// </summary>
        public StudentController(IStudentService  studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get student by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetStudents([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = studentService.GetStudents(limit,offset);

            return Ok(mapper.Map<PageResponse<StudentResponse>>(pageModel));
        }
        /// <summary>
        /// Delete student
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent([FromRoute] Guid id)
        {
            try
            {
                studentService.DeleteStudent(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get student
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent([FromRoute] Guid id)
        {
            try
            {
                var studentModel = studentService.GetStudent(id);
                return Ok(mapper.Map<AdminResponse>(studentModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update student
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel = studentService.UpdateStudent(id,mapper.Map<UpdateStudentModel>(model));
            return Ok(mapper.Map<StudentResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}