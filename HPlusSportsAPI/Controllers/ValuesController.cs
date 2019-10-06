using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsAPI.Controllers
{

    public class Value
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<Value> listValues = new List<Value>();
        public ValuesController()
        {
        listValues = new List<Value>
            {
                new Value{ Id=1,Name="Value 1"},
                    new Value{ Id=2,Name="Value 2"},
                        new Value{ Id=3,Name="Value 3"},
                            new Value{ Id=4,Name="Value 4"},
                                new Value{ Id=5,Name="Value 5"},
                                    new Value{ Id=6,Name="Value 6"},
                                        new Value{ Id=7,Name="Value 7"}
            };
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Value>> Get()
        {
            // return new string[] { "value1", "value2" };

            return listValues;
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
    }
}
