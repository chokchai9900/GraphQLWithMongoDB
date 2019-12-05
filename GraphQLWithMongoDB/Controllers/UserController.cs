using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLWithMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(userService.GetAllUser());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            return new ObjectResult(userService.GetUserByID(id));
        }
        [HttpGet("{active}")]
        public IActionResult GetUserByActive(bool active)
        {
            return new ObjectResult(userService.GetUserByActive(active));
        }
    }
}