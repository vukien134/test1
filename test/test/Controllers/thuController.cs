using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace test.Controllers
{
    public class thuController : ApiController
    {
        [HttpGet]
        [Route("api/Test/thu")]
        public IEnumerable<thu> Get()
        {
            TestEntities db = new TestEntities();
            return db.thus.ToList();

        }
        //[HttpGet]
        //[Route("api/Test/thu")]
        //public thu Get(Int32 id)
        //{
        //    TestEntities db = new TestEntities();
        //    return db.thus.FirstOrDefault(e => e.id == id);

        //}

    }
}
