using System;
using GraphQL;
using GraphQL.Types;

namespace AspNetCoreProject.GQLeprosyModel
{
	public class LeprosySchema: Schema
    {
        public LeprosySchema(IDependencyResolver resolver):base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
            Mutation = resolver.Resolve<LeprosyMutation>();

        }
    }
}
