using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreProject.LeprosyModelInterface;
using AspNetCoreProject.DataAccess;
using AspNetCoreProject.LeprosyModel;


namespace AspNetCoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            SchoolDBContext db = new SchoolDBContext();

            var dbx = new List<string>(){"value1", "value2"};

            if (db.Artists.Count() > 21){
                foreach (var name in db.Artists)
                {
                    dbx.Add(name.ArtistName);
                }
            }
            else {

                db.Artists.Add(new Artists()
                {
                     ArtistName = "Hamlet",
                    Age= 100

                });
            }

            db.SaveChanges();



            return dbx.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public void MyMapper(LeprosyMapperInterface mapper){
            mapper.MapFromLep(mapperx => mapperx.ToString());
            
        }
    }
}
