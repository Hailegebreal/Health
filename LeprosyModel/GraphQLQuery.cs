using System;
using Newtonsoft.Json.Linq;

namespace AspNetCoreProject.LeprosyModel
{
   
    
public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }

        // Actual Query
        public string Query { get; set; }
        //variables inputs
        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }




}

