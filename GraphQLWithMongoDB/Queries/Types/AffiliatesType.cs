using GraphQL.Types;
using GraphQLWithMongoDB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Queries.Types
{
    public class AffiliatesType : ObjectGraphType<AffiliateModel>
    {
        public AffiliatesType()
        {
            Field(x => x.address);
            Field(x => x.AffiliatesName);
        }
    }
}
