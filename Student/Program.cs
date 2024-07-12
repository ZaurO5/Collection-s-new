namespace Student
{
    public class Program
    {
        public static void Main()
        {
            Student student = new Student();
            student.AddGrade("Zaur", 85);
            student.AddGrade("Zaur", 90);
            student.AddGrade("Anar", 78);

            Console.WriteLine("All Grades for Zaur:");
            foreach (var grade in student.GetAllGradesByStudent("Zaur"))
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine($"Average Grade for Zaur: {student.GetAverageGrade("Zaur")}");

            student.RemoveGrade("Zaur", 90);
            Console.WriteLine("All Grades for Zaur after removing a grade:");
            foreach (var grade in student.GetAllGradesByStudent("Zaur"))
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine($"Average Grade for Zaur: {student.GetAverageGrade("Zaur")}");
        }
    }
}