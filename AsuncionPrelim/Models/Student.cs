namespace AsuncionPrelim.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<int> Marks { get; set; } = new List<int>();

        public int TotalMarks => Marks.Sum();
        public double AverageMarks => Marks.Count > 0 ? Marks.Average() : 0.0;

        // Overload the '>' operator to compare total marks between two students
        public static bool operator >(Student s1, Student s2)
        {
            return s1.TotalMarks > s2.TotalMarks;
        }

        public static bool operator <(Student s1, Student s2)
        {
            return s1.TotalMarks < s2.TotalMarks;
        }
    }
}
