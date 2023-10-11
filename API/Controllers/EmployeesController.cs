using API.Entity.Repository;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyDbContext _db;
        public EmployeesController(MyDbContext db)
        {
            _db = db;   
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            var x =_db.Employees.ToList();
            return Ok(x);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int id)
        {
            var x =_db.Employees.FirstOrDefault(e=>e.Id==id);
            return Ok(x);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult insert(Employee Emp)
        {
            var x =_db.Employees.Add(Emp);
            _db.SaveChanges();
            return Ok("Done");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult update(Employee Emp)
        {
            var x =_db.Employees.Update(Emp);
            _db.SaveChanges();
            return Ok("Updated");
        }

    }
}
