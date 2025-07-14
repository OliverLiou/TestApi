using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private static List<Course> courses = new List<Course>();
        private static List<Student> students = new List<Student>();

        // 課程 CRUD
        [HttpPost("course/add")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            courses.Add(course);
            return Ok(course);
        }

        [HttpPut("course/update/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            course.Name = updatedCourse.Name;
            course.Description = updatedCourse.Description;
            return Ok(course);
        }

        [HttpDelete("course/delete/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            courses.Remove(course);
            return Ok();
        }

        // 學生 CRUD
        [HttpPost("student/add")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("student/update/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            return Ok(student);
        }

        [HttpDelete("student/delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            students.Remove(student);
            return Ok();
        }
    }
}
