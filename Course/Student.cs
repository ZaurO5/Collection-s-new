namespace CourseApp
{
    public class Student
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(string name, string surname, int age, double grade)
        {
            Id = nextId++;
            Name = name;
            Surname = surname;
            Age = age;
            Grade = grade;
        }
    }
}
