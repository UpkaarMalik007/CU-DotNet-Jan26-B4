namespace StudentCourseManagement.DTOs
{
    public class CourseDto
    {
        public class CreateCourseDto
        {
            public string Title { get; set; }
            public int Credits { get; set; }
        }

        public class UpdateCourseDto
        {
            public string Title { get; set; }
            public int Credits { get; set; }
        }

        public class CourseResponseDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }
        }
    }
}
