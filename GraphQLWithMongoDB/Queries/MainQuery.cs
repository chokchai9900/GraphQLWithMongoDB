using GraphQL.Types;
using GraphQLWithMongoDB.Queries.Types;
using GraphQLWithMongoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Queries
{
    public class MainQuery : ObjectGraphType
    {
        public MainQuery(MainService mainService)
        {
            //work
            Field<ListGraphType<UserType>>(
                name: "GetAllUser",
                resolve: context => mainService.GetAllUser());

            Field<UserType>(
                name: "GetUserByID",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return mainService.GetUserByID(id);
                }
            );

            Field<ListGraphType<CompanyType>>(
                name: "GetAllCompany",
                resolve: context => mainService.GetAllCompany());

            Field<CompanyType>(
                name: "GetCompanyByID",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return mainService.GetCompanyByID(id);
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
