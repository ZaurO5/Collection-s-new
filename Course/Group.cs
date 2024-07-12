using System;
using System.Collections.Generic;

namespace CourseApp
{
    public class Group
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        private List<Student> students;

        public Group(string name, int limit)
        {
            Id = nextId++;
            Name = name;
            Limit = limit;
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (students.Exists(s => s.Id == student.Id))
            {
                Console.WriteLine("Bu ID ilə tələbə artıq mövcuddur.");
            }
            else if (students.Count >= Limit)
            {
                Console.WriteLine("Qrup limiti dolub.");
            }
            else
            {
                students.Add(student);
                Console.WriteLine("Tələbə əlavə edildi.");
            }
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void RemoveStudent(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Tələbə silindi.");
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı.");
            }
        }

        public Student GetStudentById(int id)
        {
            return students.Find(s => s.Id == id);
        }
    }
}
