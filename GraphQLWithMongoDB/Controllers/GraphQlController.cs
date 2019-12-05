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
    public class GraphQlController : Controller 
    {
        readonly UserService userService;
        public GraphQlController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new UserQuery(userService) };
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