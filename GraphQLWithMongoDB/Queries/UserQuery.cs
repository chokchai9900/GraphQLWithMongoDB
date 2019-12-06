using GraphQL.Types;
using GraphQLWithMongoDB.Queries.Types;
using GraphQLWithMongoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(UserService userService)
        {
            //work
            Field<ListGraphType<UserType>>(
                name: "GetAllUser",
                resolve: context => userService.GetAllUser());

            Field<UserType>(
                name: "GetUserByID",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return userService.GetUserByID(id);
                }
            );


            //fail
            //Field<UserType>(
            //    name: "GetUserByActive",
            //    arguments: new QueryArguments(new QueryArgument<BooleanGraphType> { Name = "active" }),
            //    resolve: context =>
            //    {
            //        var active = context.GetArgument<bool>("active");
            //        return userService.GetUserByActive(active);
            //    }

            //);

        }

    }
}
