using System;
using System.Collections.Generic;

namespace Student
{
    public class Student
    {
        public Dictionary<string, List<int>>
        Grades { get; set; }

        public Student()
        {
            Grades = new Dictionary<string, List<int>>();
        }
        public void AddGrade(string studentName, int grade)
        {
            if (!Grades.ContainsKey(studentName))
            {
                Grades[studentName] = new List<int>();
            }
            Grades[studentName].Add(grade);
            Console.WriteLine($"Student and grade: {studentName} {grade}.");
        }
        public void RemoveGrade(string studentName, int grade)
        {
            if (Grades.ContainsKey(studentName))
            {
                if (Grades[studentName].Remove(grade))
                {
                    Console.WriteLine($"Student and removed grade: {studentName} {grade}.");
                }
                else
                {
                    Console.WriteLine($"removed grade not found for student: {studentName} {grade}.");
                }
            }
            else
            {
                Console.WriteLine($"Student {studentName} not found.");
            }
        }
        public double GetAverageGrade(string studentName)
        {
            if (Grades.ContainsKey(studentName) && Grades[studentName].Count > 0)
            {
                return Grades[studentName].Average();
            }
            else
            {
                Console.WriteLine($"No grades found for student {studentName}.");
                return 0;
            }
        }

        public List<int> GetAllGradesByStudent(string studentName)
        {
            if (Grades.ContainsKey(studentName))
            {
                return Grades[studentName];
            }
            else
            {
                Console.WriteLine($"Student {studentName} not found.");
                return new List<int>();
            }
        }
    }
}
