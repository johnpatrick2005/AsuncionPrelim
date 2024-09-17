using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AsuncionPrelim.Models;
using System.Linq;

namespace AsuncionPrelim.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Student Student1 { get; set; } = new Student();

        [BindProperty]
        public Student Student2 { get; set; } = new Student();

        [BindProperty]
        public string Marks1 { get; set; } = string.Empty;

        [BindProperty]
        public string Marks2 { get; set; } = string.Empty;

        public string TotalMarks1 { get; set; } = string.Empty;
        public string AverageMarks1 { get; set; } = string.Empty;
        public string TotalMarks2 { get; set; } = string.Empty;
        public string AverageMarks2 { get; set; } = string.Empty;
        public string ComparisonResult { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPostCalculate()
        {
            // Parse and set marks for Student1
            if (!string.IsNullOrEmpty(Marks1))
            {
                Student1.Marks = ParseMarks(Marks1);
            }

            // Parse and set marks for Student2
            if (!string.IsNullOrEmpty(Marks2))
            {
                Student2.Marks = ParseMarks(Marks2);
            }

            // Calculate totals and averages
            TotalMarks1 = Student1.TotalMarks.ToString();
            AverageMarks1 = Student1.AverageMarks.ToString("F2");
            TotalMarks2 = Student2.TotalMarks.ToString();
            AverageMarks2 = Student2.AverageMarks.ToString("F2");

            // Compare students using overloaded operators
            if (Student1 > Student2)
            {
                ComparisonResult = $"{Student1.Name} has higher marks than {Student2.Name}.";
            }
            else if (Student1 < Student2)
            {
                ComparisonResult = $"{Student2.Name} has higher marks than {Student1.Name}.";
            }
            else
            {
                ComparisonResult = $"{Student1.Name} and {Student2.Name} have the same total marks.";
            }
        }

        private List<int> ParseMarks(string marksString)
        {
            // Split the string by comma, trim spaces, and parse each to an integer
            return marksString.Split(',')
                              .Select(m =>
                              {
                                  int.TryParse(m.Trim(), out int mark);
                                  return mark;
                              })
                              .ToList();
        }
    }
}
