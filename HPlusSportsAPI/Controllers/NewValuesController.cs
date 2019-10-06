using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Controllers
{
    public class Demo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    
    public class NewDemosController : ControllerBase
    {
        List<Demo> listDemos = new List<Demo>();
        public NewDemosController()
        {
            listDemos = new List<Demo>
            {
                new Demo{ Id=1,Name="Demo 1"},
                    new Demo{ Id=2,Name="Demo 2"},
                        new Demo{ Id=3,Name="Demo 3"},
                            new Demo{ Id=4,Name="Demo 4"},
                                new Demo{ Id=5,Name="Demo 5"},
                                    new Demo{ Id=6,Name="Demo 6"},
                                        new Demo{ Id=7,Name="Demo 7"}
            };
        }
        [Route("api/Tayyab/[controller]")]
        [HttpGet]
        public IEnumerable<Demo>Get()
        {
            return listDemos;
        }
        [Route("api/GetResult")]
        [HttpGet("{Id}")]
        public Demo Get(int id)
        {
            return listDemos.Where(s => s.Id == id).SingleOrDefault();
        }
    }
}
