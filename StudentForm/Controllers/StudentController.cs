using Microsoft.AspNetCore.Mvc;
using StudentForm.Models;
using StudentForm.Repositories;

namespace StudentForm.Controllers
{
    public class StudentController : Controller
    {
        private IDBManager _dbManager;
        public StudentController( IDBManager dbManager )
        {
            _dbManager = dbManager;
        }
        public IActionResult GetAll()
         {
            var Students = _dbManager.GetAll();
            return Json(Students);
        }
        public IActionResult GetById(int id) 
        {
            var student = _dbManager.GetById(id);
            return Json(student);
        }
        [HttpPost("Student/Insert")]
        public IActionResult Insert([FromBody] Student student) 
        {
            if (student!=null)
            {
                _dbManager.Insert(student);
                _dbManager.save();

                return Ok();
            }
            return RedirectToAction("GetAll");
        }
        public IActionResult Delete(int id) 
        {
            _dbManager.DeleteById(id);
            return Ok();
        }
        public IActionResult Update([FromBody] Student student)
        {
            var s = _dbManager.GetById(student.id);
            s.name = student.name;
            s.address = student.address;
            _dbManager.Update(s);
            return Ok(student);
        }
        [HttpGet("status/{status:bool}")]
        public IActionResult SearchByStatus(bool status)
        {
            var student = _dbManager.GetByStatus(status);
            return Json(student);
        }
        public IActionResult SortByStatus()
        {
            return Json(_dbManager.SortByStatus());
        }
        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            return Json(_dbManager.Login(login));
        }
        [HttpPost]
        public IActionResult UpdateByLogin( [FromBody] Student student)
        {
            /*if(login == null)
            {
                return Unauthorized("Please Login");
            }
            var s = _dbManager.Login(login);
            if (s == null)
            {
                return Unauthorized("Wrong email or password");
            }*/
            Update(student);
            return Ok(student);
        }
    }
}
