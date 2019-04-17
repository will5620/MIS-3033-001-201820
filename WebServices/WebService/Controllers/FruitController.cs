using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class FruitController : ApiController
    {
        // GET api/<controller>
        public Fruit Get()
        {
            return new Fruit()
            {
                Name = "Banana",
                Ounces = 7.8
            };
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

    }
}