using System;
using GraphQL.Types;
namespace AspNetCoreProject.GQLeprosyModel
{
    public class LeprosyQuery: ObjectGraphType
    {
        public LeprosyQuery(IQLPatientRepository patientRepository)
        {
        }
    }
}
