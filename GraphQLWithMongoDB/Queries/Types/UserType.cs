using GraphQL.Types;
using GraphQLWithMongoDB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Queries.Types
{
    public class UserType : ObjectGraphType<userModel>
    {
        public UserType()
        {
            Field(x => x._id).Description("ID user");
            Field(x => x.index).Description("index of user");
            Field(x => x.guid).Description("GUID of user");
            Field(x => x.isActive).Description("User is Active ?");
            Field(x => x.balance).Description("balance in account");
            Field(x => x.picture).Description("picture of user");
            Field(x => x.age).Description("age");
            Field(x => x.eyeColor).Description("eyeColor");
            Field(x => x.name).Description("name");
            Field(x => x.subname).Description("sub name");
            Field(x => x.company).Description("company");
            Field(x => x.email).Description("email");
            Field(x => x.phone).Description("phone number");
            Field(x => x.address).Description("address");
            Field(x => x.registered).Description("registered");
            Field(x => x.latitude).Description("latitude of address");
            Field(x => x.longitude).Description("longitude of address");
            Field(x => x.greeting).Description("api is say ...");
            Field(x => x.favoriteFruit).Description("favorite Fruit");
        }
    }
}
