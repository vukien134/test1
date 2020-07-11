using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Net.Mime.MediaTypeNames;

namespace test.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable<sanpham> Get()
        {
            TestEntities db = new TestEntities();
            return db.sanphams.ToList();

        }

        public sanpham Get(Int32 id)
        {
            TestEntities db = new TestEntities();
            return db.sanphams.FirstOrDefault(e => e.id == id);

        }
        //public IEnumerable<thu> Get()
        //{
        //    TestEntities1 db = new TestEntities1();
        //    return db.thus.ToList();

        //}
        //[HttpGet]
        //[Route("/api/Test/thu")]
        //public thu Get(int id)
        //{
        //    TestEntities1 db = new TestEntities1();
        //    return db.thus.FirstOrDefault(e => e.id == id);

        //}


        [HttpGet]
        [Route("api/Test/timkiem")]
        public IQueryable<sanpham> timkiem(string timkiem)
        {

            TestEntities db = new TestEntities();
                return db.sanphams.Where(x => x.tenSp==timkiem);
           
        }


        [HttpPost]
        [Route("api/Test/insert")]
        public bool insert(JObject model)
        {
            var id = Convert.ToInt32(model["id"]);
            var tenSp = Convert.ToString(model["tenSp"]);
            var giaSp = Convert.ToDouble(model["giaSp"]);
            TestEntities db = new TestEntities();
            sanpham sp = new sanpham();
            sp.id = id;
            sp.tenSp = tenSp;
            sp.giaSp = giaSp;
            db.sanphams.Add(sp);
            db.SaveChanges();
            return true;
        }



        [HttpPost]
        [Route("api/Test/update")]
        public bool update(JObject model)
        {
            var id = Convert.ToInt32(model["id"]);
            var tenSp = Convert.ToString(model["tenSp"]);
            var giaSp = Convert.ToDouble(model["giaSp"]);
            TestEntities db = new TestEntities();
            sanpham sp = db.sanphams.FirstOrDefault(x => x.id == id);
            if (sp == null)
            {
                return false;
            }
            sp.id = id;
            sp.tenSp = tenSp;
            sp.giaSp = giaSp;
            db.SaveChanges();
            return true;
        }
        [HttpPost]
        [Route("api/Test/delete")]
        public bool delete(JObject model)
        {
            var id = Convert.ToInt32(model["id"]);

            TestEntities db = new TestEntities();

            sanpham sp = db.sanphams.Find(id);
            if (sp == null)
            {
                return false;
            }
            db.sanphams.Remove(sp);
            db.SaveChanges();
            return true;
        }



    }
}
