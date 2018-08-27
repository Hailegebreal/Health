using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using AspNetCoreProject.LeprosyModel;
using AspNetCoreProject.Repositories;
using AspNetCoreProject.GQLeprosyModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreProject.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        private readonly IBookRepository _bookRepository;
        public GraphQLController(ISchema schema,IDocumentExecuter documentExecuter, IBookRepository bookRepository){
           
            _documentExecuter = documentExecuter;
            _schema = schema;
            _bookRepository = bookRepository;
            
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            
            var inputs =  query.Variables.ToInputs();

            //new BookQuery(_bookRepository),

            var schemax = new Schema
            {
                Query = _schema.Query   ,
                Mutation = _schema.Mutation


            };
            var executionOptions = new ExecutionOptions
            {
                Schema = schemax,
                Query = query.Query,
                Inputs = inputs

            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);

            if(result.Errors?.Count>0){
                return BadRequest(result);
            }

            return Ok(result);

           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
