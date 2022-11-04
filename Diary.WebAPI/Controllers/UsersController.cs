using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Diary.Entity.Migrations;
using Diary.Entity.Models;
using Diary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<Student> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.GetAll();
            return Ok(users);
        }
        /// <summary>
        /// Get users
        /// </summary>
        /// <param name="student"></param>
        [HttpGet]
        public IActionResult GetUsers(Guid id)
        {
            var student = _repository.GetById(id);
            return Ok(student);
        }
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="student"></param>
        [HttpDelete]
        public IActionResult DeleteUsers(Student student)
        {
            _repository.Delete(student);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="student"></param>
        [HttpPost]
        public IActionResult PostUsers(Student student)
        {
            var result = _repository.Save(student);
            return Ok(result);
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="student"></param>
        [HttpPut]
        public IActionResult Updatesers(Student student)
        {
            return PostUsers(student);
        }

    }

}