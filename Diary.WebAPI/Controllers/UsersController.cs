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
        private IRepository<s> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
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
        /// <param name="users"></param>
        [HttpGet]
        public IActionResult GetUsers(Guid id)
        {
            var users = _repository.GetById(id);
            return Ok(users);
        }
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="users"></param>
        [HttpDelete]
        public IActionResult DeleteUsers( user)
        {
            _repository.Delete(user);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="users"></param>
        [HttpPost]
        public IActionResult PostUsers( user)
        {
            var result = _repository.Save(user);
            return Ok(result);
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="users"></param>
        [HttpPut]
        public IActionResult Updatesers(User user)
        {
            return PostUsers(user);
        }

    }

}