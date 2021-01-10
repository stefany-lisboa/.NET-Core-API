using System.ComponentModel.DataAnnotations;

namespace SS_API.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string Name { get; set; }
    }
}