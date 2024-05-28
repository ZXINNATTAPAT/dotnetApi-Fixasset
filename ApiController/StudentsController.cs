// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using WebApplication1.Models;

// namespace WebApplication1.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class StudentsController : ControllerBase
//     {
//         private readonly SchoolContext _context;

//         public StudentsController(SchoolContext context)
//         {
//             _context = context;
//         }

//         // GET: api/students
//         [HttpGet]
//         public ActionResult<IEnumerable<Student>> GetStudents()
//         {
//             return _context.Students.ToList();
//         }

//         // GET: api/students/5
//         [HttpGet("{id}")]
//         public ActionResult<Student> GetStudent(int id)
//         {
//             var student = _context.Students.Find(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }

//             return student;
//         }

//         // POST: api/students
//         [HttpPost]
//         public ActionResult<Student> PostStudent(Student student)
//         {
//             _context.Students.Add(student);
//             _context.SaveChanges();

//             return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
//         }

//         // PUT: api/students/5
//         [HttpPut("{id}")]
//         public IActionResult PutStudent(int id, Student student)
//         {
//             if (id != student.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(student).State = EntityState.Modified;
//             _context.SaveChanges();

//             return NoContent();
//         }

//         // DELETE: api/students/5
//         [HttpDelete("{id}")]
//         public IActionResult DeleteStudent(int id)
//         {
//             var student = _context.Students.Find(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }

//             _context.Students.Remove(student);
//             _context.SaveChanges();

//             return NoContent();
//         }
//     }
// }
