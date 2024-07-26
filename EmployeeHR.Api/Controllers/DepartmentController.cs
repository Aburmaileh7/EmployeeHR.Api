using EmployeeHR.Api.Data;
using EmployeeHR.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHR.Api.Controllers
{
    [ApiController]
    //[Route("api/{Controller}")]
    [Route("api/Department")]
    public class DepartmentController : ControllerBase
    {


        //database/////////////////////
        private readonly HRADBContext _dbContext;

        public DepartmentController(HRADBContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var dep = _dbContext.Departments.ToList();

            return Ok(dep);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
            if(dep == null)
            {
                return NotFound();
            }

            return Ok(dep);
        }


        [HttpPost]
        public IActionResult post([FromForm]Department department)
        {
            if(department == null)
            {
                return BadRequest();
            }

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return Ok(_dbContext.Departments.ToList());
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (dep == null)
            {
                return NotFound();
            }
            dep.Name = department.Name;
            _dbContext.SaveChanges();
            return Ok(_dbContext.Departments.ToList());
        }



        [HttpPatch]
        public IActionResult Patch(Department department)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (dep == null)
            {
                return NotFound();
            }
            dep.Name = department.Name;

            _dbContext.SaveChanges();
            return Ok(_dbContext.Departments.ToList());
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var dep = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            _dbContext.Departments.Remove(dep);
            _dbContext.SaveChanges();
            return Ok(_dbContext.Departments.ToList());

        }



    }

    
}
