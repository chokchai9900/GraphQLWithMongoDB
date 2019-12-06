using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLWithMongoDB.Queries;
using GraphQLWithMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLWithMongoDB.Controllers
{
    [Route(Startup.GraphQlPath)]
    [ApiController]
    public class GraphQlController : Controller 
    {
        readonly MainService mainService;
        public GraphQlController(MainService mainService)
        {
            this.mainService = mainService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new MainQuery(mainService) };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}