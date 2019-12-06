using GraphQL.Types;
using GraphQLWithMongoDB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Queries.Types
{
    public class CompanyType : ObjectGraphType<companyModel>
    {
        public CompanyType()
        {
            Field(x => x._id).Description("ID Company");
            Field(x => x.index).Description("index of Company");
            Field(x => x.guid).Description("GUID of Company");
            Field(x => x.isActive).Description("User is Active ?");
            Field(x => x.balance).Description("balance in Company");
            Field(x => x.picture).Description("picture of Company");
            Field(x => x.companyName).Description("Name of company");
            Field(x => x.email).Description("email");
            Field(x => x.phone).Description("phone number");
            Field(x => x.address).Description("address");
            Field(x => x.registered).Description("registered");
            Field(x => x.latitude).Description("latitude of address");
            Field(x => x.longitude).Description("longitude of address");
            Field<AffiliatesType>("Affiliates");
        }
    }
}
