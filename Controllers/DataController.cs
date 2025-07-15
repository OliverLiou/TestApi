using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private static List<Course> courses = new List<Course>();
        private static List<Student> students = new List<Student>();

        [HttpPost("course/add")]
        [SwaggerOperation(Summary = "新增課程", Description = "提供課程資料以新增課程")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            courses.Add(course);
            return Ok(course);
        }

        [HttpPut("course/update/{id}")]
        [SwaggerOperation(Summary = "修改課程", Description = "根據課程 ID 修改課程資料")]
        public IActionResult UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            course.Name = updatedCourse.Name;
            course.Description = updatedCourse.Description;
            return Ok(course);
        }

        [HttpDelete("course/delete/{id}")]
        [SwaggerOperation(Summary = "刪除課程", Description = "根據課程 ID 刪除課程")]
        public IActionResult DeleteCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            courses.Remove(course);
            return Ok();
        }

        [HttpPost("student/add")]
        [SwaggerOperation(Summary = "新增學生", Description = "提供學生資料以新增學生")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (students.Any(s => s.Id == student.Id))
            {
                return Conflict($"學生 Id {student.Id} 已存在。");
            }
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("student/update/{id}")]
        [SwaggerOperation(Summary = "修改學生", Description = "根據學生 ID 修改學生資料")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            return Ok(student);
        }

        [HttpDelete("student/delete/{id}")]
        [SwaggerOperation(Summary = "刪除學生", Description = "根據學生 ID 刪除學生")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            students.Remove(student);
            return Ok();
        }
    }
}
