using System;
using System.Collections.Generic;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CourseApp courseApp = new CourseApp("Programlaşdırma Kursu");

            while (true)
            {
                Console.WriteLine("\nMenyudan seçim edin:");
                Console.WriteLine("1. Qrup əlavə et");
                Console.WriteLine("2. Qrupları gör");
                Console.WriteLine("3. Qrupu redaktə et");
                Console.WriteLine("4. Qrupu sil");
                Console.WriteLine("5. Qrupa tələbə əlavə et");
                Console.WriteLine("6. Qrupdaki tələbələri gör");
                Console.WriteLine("7. Kursdaki tələbələri gör");
                Console.WriteLine("8. Tələbələr üzrə axtarış");
                Console.WriteLine("9. Qrupdan tələbə sil");
                Console.WriteLine("10. Qrupdaki tələbəni redaktə et");
                Console.WriteLine("11. Çıxış");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddGroup(courseApp);
                        break;
                    case "2":
                        courseApp.ShowGroups();
                        break;
                    case "3":
                        EditGroup(courseApp);
                        break;
                    case "4":
                        RemoveGroup(courseApp);
                        break;
                    case "5":
                        AddStudentToGroup(courseApp);
                        break;
                    case "6":
                        ShowStudentsInGroup(courseApp);
                        break;
                    case "7":
                        ShowAllStudentsInCourse(courseApp);
                        break;
                    case "8":
                        SearchStudents(courseApp);
                        break;
                    case "9":
                        RemoveStudentFromGroup(courseApp);
                        break;
                    case "10":
                        EditStudentInGroup(courseApp);
                        break;
                    case "11":
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                        break;
                }
            }
        }

        static void AddGroup(CourseApp courseApp)
        {
            Console.Write("Qrupun adı: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Qrupun adı boş ola bilməz.");
                return;
            }

            Console.Write("Qrupun limiti: ");
            if (!int.TryParse(Console.ReadLine(), out int limit) || limit <= 0)
            {
                Console.WriteLine("Limiti düzgün daxil edin.");
                return;
            }

            Group group = new Group(name, limit);
            course.AddGroup(group);
        }

        static void EditGroup(Course course)
        {
            Console.Write("Redaktə etmək istədiyiniz qrupun adı: ");
            string name = Console.ReadLine();
            Group group = course.GetGroupByName(name);

            if (group != null)
            {
                Console.Write("Yeni ad: ");
                string newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine("Yeni ad boş ola bilməz.");
                    return;
                }

                Console.Write("Yeni limit: ");
                if (!int.TryParse(Console.ReadLine(), out int newLimit) || newLimit <= 0)
                {
                    Console.WriteLine("Yeni limiti düzgün daxil edin.");
                    return;
                }

                group.Name = newName;
                group.Limit = newLimit;
                Console.WriteLine("Qrup redaktə edildi.");
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        static void RemoveGroup(Course course)
        {
            Console.Write("Silinmək istədiyiniz qrupun adı: ");
            string name = Console.ReadLine();
            if (course.RemoveGroup(name))
            {
                Console.WriteLine("Qrup silindi.");
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        static void AddStudentToGroup(Course course)
        {
            course.ShowGroups();
            Console.Write("Tələbə əlavə etmək istədiyiniz qrupun adı: ");
            string groupName = Console.ReadLine();
            Group group = course.GetGroupByName(groupName);

            if (group != null)
            {
                Console.Write("Tələbənin adı: ");
                string name = Console.ReadLine();
                Console.Write("Tələbənin soyadı: ");
                string surname = Console.ReadLine();
                Console.Write("Tələbənin yaşı: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Yaşı düzgün daxil edin.");
                    return;
                }
                Console.Write("Tələbənin qiyməti: ");
                if (!double.TryParse(Console.ReadLine(), out double grade) || grade < 0 || grade > 100)
                {
                    Console.WriteLine("Qiyməti düzgün daxil edin.");
                    return;
                }

                Student student = new Student(name, surname, age, grade);
                if (group.AddStudent(student))
                {
                    Console.WriteLine("Tələbə əlavə edildi.");
                }
                else
                {
                    Console.WriteLine("Qrup limiti doludur.");
                }
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        static void ShowStudentsInGroup(Course course)
        {
            course.ShowGroups();
            Console.Write("Tələbələrini görmək istədiyiniz qrupun adı: ");
            string groupName = Console.ReadLine();
            Group group = course.GetGroupByName(groupName);

            if (group != null)
            {
                List<Student> students = group.GetStudents();
                if (students.Count == 0)
                {
                    Console.WriteLine("Bu qrupda tələbə yoxdur.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Ad: {student.Name}, Soyad: {student.Surname}, Yaş: {student.Age}, Qiymət: {student.Grade}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        static void ShowAllStudentsInCourse(Course course)
        {
            List<Student> students = course.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("Kursda tələbə yoxdur.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Ad: {student.Name}, Soyad: {student.Surname}, Yaş: {student.Age}, Qiymət: {student.Grade}");
                }
            }
        }

        static void SearchStudents(Course course)
        {
            Console.Write("Axtarış üçün string dəyər daxil edin: ");
            string searchString = Console.ReadLine();
            List<Student> allStudents = course.GetAllStudents();

            List<Student> foundStudents = allStudents.FindAll(s => s.Name.Contains(searchString) || s.Surname.Contains(searchString));
            if (foundStudents.Count == 0)
            {
                Console.WriteLine("Heç bir tələbə tapılmadı.");
            }
            else
            {
                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"ID: {student.Id}, Ad: {student.Name}, Soyad: {student.Surname}, Yaş: {student.Age}, Qiymət: {student.Grade}");
                }
            }
        }

        static void RemoveStudentFromGroup(Course course)
        {
            course.ShowGroups();
            Console.Write("Tələbə silmək istədiyiniz qrupun adı: ");
            string groupName = Console.ReadLine();
            Group group = course.GetGroupByName(groupName);

            if (group != null)
            {
                List<Student> students = group.GetStudents();
                if (students.Count == 0)
                {
                    Console.WriteLine("Bu qrupda tələbə yoxdur.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Ad: {student.Name}");
                    }

                    Console.Write("Silinməli tələbənin ID-sini daxil edin: ");
                    if (!int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("ID düzgün daxil edilməyib.");
                        return;
                    }

                    if (group.RemoveStudent(studentId))
                    {
                        Console.WriteLine("Tələbə silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Tələbə tapılmadı.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }

        static void EditStudentInGroup(Course course)
        {
            course.ShowGroups();
            Console.Write("Tələbə redaktə etmək istədiyiniz qrupun adı: ");
            string groupName = Console.ReadLine();
            Group group = course.GetGroupByName(groupName);

            if (group != null)
            {
                List<Student> students = group.GetStudents();
                if (students.Count == 0)
                {
                    Console.WriteLine("Bu qrupda tələbə yoxdur.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Ad: {student.Name}");
                    }

                    Console.Write("Redaktə etmək istədiyiniz tələbənin ID-sini daxil edin: ");
                    if (!int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("ID düzgün daxil edilməyib.");
                        return;
                    }

                    Student student = group.GetStudentById(studentId);

                    if (student != null)
                    {
                        Console.Write("Yeni ad: ");
                        string newName = Console.ReadLine();
                        Console.Write("Yeni soyad: ");
                        string newSurname = Console.ReadLine();
                        Console.Write("Yeni yaş: ");
                        if (!int.TryParse(Console.ReadLine(), out int newAge) || newAge <= 0)
                        {
                            Console.WriteLine("Yeni yaşı düzgün daxil edin.");
                            return;
                        }
                        Console.Write("Yeni qiymət: ");
                        if (!double.TryParse(Console.ReadLine(), out double newGrade) || newGrade < 0 || newGrade > 100)
                        {
                            Console.WriteLine("Yeni qiyməti düzgün daxil edin.");
                            return;
                        }

                        student.Name = newName;
                        student.Surname = newSurname;
                        student.Age = newAge;
                        student.Grade = newGrade;
                        Console.WriteLine("Tələbə redaktə edildi.");
                    }
                    else
                    {
                        Console.WriteLine("Tələbə tapılmadı.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Qrup tapılmadı.");
            }
        }
    }
}
