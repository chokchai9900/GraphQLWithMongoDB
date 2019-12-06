using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLWithMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly MainService mainService;
        public CompanyController(MainService mainService)
        {
            this.mainService = mainService;
        }
        [HttpGet]
        public IActionResult GetAllCompany()
        {
            return new ObjectResult(mainService.GetAllCompany());
        }
        [HttpGet("{id}")]
        public IActionResult GetCompanyById(string id)
        {
            return new ObjectResult(mainService.GetCompanyByID(id));
        }
    }
}