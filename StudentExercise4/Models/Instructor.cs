namespace StudentExercise4.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorSlackHandle { get; set; }
        public int instructor_cohort_id { get; set; }
    }
}