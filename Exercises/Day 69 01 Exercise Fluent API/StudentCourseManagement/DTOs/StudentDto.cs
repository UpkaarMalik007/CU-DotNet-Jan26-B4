using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagement.DTOs
{
    public class StudentDto
    {
        public class CreateStudentDto
        {
            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }

        public class UpdateStudentDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }

        public class StudentResponseDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }
    }
}
