using _16_09_2019.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_09_2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelesukController : ControllerBase
    {
        private TelesukContext context;
        public TelesukController(TelesukContext db)
        {
            context = db;
        }
        // GET
        [HttpGet("read")]
        public ContentResult Get()
        {
            return Content(JsonConvert.SerializeObject(context.Telesuky.ToList()), "aplication/json");
        }
        // POST
        [HttpPost("create")]
        public void Create([FromBody] Telesuk telesuk)
        {
            context.Telesuky.Add(telesuk);
            context.SaveChanges();
        }
        // PUT
        [HttpPut("update/{id}")]
        public void Update(int id, [FromBody] Telesuk telesuk)
        {
            var item = context.Telesuky.FirstOrDefault(t=>t.Id==id);
            if (item != null)
            {
                item.FirstName = telesuk.FirstName;
                item.LastName = telesuk.LastName;
                item.Age = telesuk.Age;
                item.Adress = telesuk.Adress;
                item.IsMarried = telesuk.IsMarried;
                context.SaveChanges();
            }
        }
        //DELETE
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            var item = context.Telesuky.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                context.Telesuky.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
