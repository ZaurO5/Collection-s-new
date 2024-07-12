using System;
using System.Collections.Generic;

namespace CourseApp
{
    public class Course
    {
        public string Name { get; set; }
        private List<Group> groups;

        public Course(string name)
        {
            Name = name;
            groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            if (groups.Exists(g => g.Name == group.Name))
            {
                Console.WriteLine("Eyni adlı qrup artıq mövcuddur.");
            }
            else
            {
                groups.Add(group);
                Console.WriteLine("Qrup əlavə edildi.");
            }
        }

        public void ShowGroups()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup yoxdur.");
            }
            else
            {
                foreach (var group in groups)
                {
                    Console.WriteLine($"ID: {group.Id}, Name: {group.Name}, Limit: {group.Limit}");
                }
            }
        }

        public Group GetGroupByName(string name)
        {
            return groups.Find(g => g.Name == name);
        }

        public void RemoveGroup(string name)
        {
            Group group = GetGroupByName(name);
            if (group != null)
            {
                groups.Remove(group);
                Console.WriteLine("Qrup silindi.");
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        public List<Group> GetAllGroups()
        {
            return groups;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();
            foreach (var group in groups)
            {
                allStudents.AddRange(group.GetStudents());
            }
            return allStudents;
        }
    }
}
