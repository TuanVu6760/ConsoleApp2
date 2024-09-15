//Huỳnh Tuấn Vũ
//22DTG1
//2280603730
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap
{
    public class Student
    {
        private int id;
        private string name;
        private int age;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Student() { }

        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public void Input()
        {
            Console.WriteLine("Nhập ID:");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập họ và tên:");
            name = Console.ReadLine();
            Console.WriteLine("Nhập tuổi:");
            age = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine("ID:{0}, Name:{1}, Age:{2}", id, name, age);
        }

        public static void ThemHS(List<Student> studentsList)
        {
            Console.WriteLine("Nhập thông tin học sinh:");
            Student student = new Student();
            student.Input();
            studentsList.Add(student);
        }

        public static void XuatDS(List<Student> studentsList)
        {
            Console.WriteLine("Danh sách thông tin học sinh:");
            foreach (Student student in studentsList)
            {
                student.Output();
            }
        }

        public static string GetMainName(string fullName)
        {
            var parts = fullName.Split(' ');
            return parts.Length > 1 ? parts.Last() : fullName;
        }

        public static void Tongtuoi(List<Student> studentsList)
        {
            int totalAge = studentsList.Sum(s => s.Age);
            Console.WriteLine("Tổng tuổi của tất cả học sinh: " + totalAge);
        }

        public static void HStuoiMax(List<Student> studentsList)
        {
            var oldestStudent = studentsList.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
            {
                Console.WriteLine("Học sinh có tuổi lớn nhất:");
                oldestStudent.Output();
            }
            else
            {
                Console.WriteLine("Danh sách học sinh trống.");
            }
        }

        public static void DStuoitangdan(List<Student> studentsList)
        {
            var sortedStudents = studentsList.OrderBy(s => s.Age).ToList();
            Console.WriteLine("Danh sách học sinh sắp xếp theo tuổi tăng dần:");
            foreach (Student student in sortedStudents)
            {
                student.Output();
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.Unicode;
                List<Student> students = new List<Student>
                {
                    new Student(1, "Huỳnh Tuấn Vũ", 18),
                    new Student(2, "Lê Duy Vũ", 20),
                    new Student(3, "Trần Trọng Tấn", 15),
                    new Student(4, "Nguyễn An Khang", 17),
                    new Student(5, "Trương Công Viên", 20),
                    new Student(6, "Phạm Hoàng Tuấn Kha", 22),
                    new Student(7, "Nguyễn Văn A", 23)
                };

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("==== Menu ====");
                    Console.WriteLine("1. Thêm học sinh");
                    Console.WriteLine("2. Hiển thị danh sách học sinh");
                    Console.WriteLine("3. Danh sách học sinh có tuổi từ 15 đến 18");
                    Console.WriteLine("4. Danh sách học sinh có tên chính bắt đầu bằng chữ A");
                    Console.WriteLine("5. Tính tổng tuổi của tất cả học sinh");
                    Console.WriteLine("6. Tìm và in ra học sinh có tuổi lớn nhất");
                    Console.WriteLine("7. Sắp xếp danh sách học sinh theo tuổi tăng dần");
                    Console.WriteLine("0. Thoát");
                    Console.WriteLine("Mời chọn chức năng:");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Student.ThemHS(students);
                            break;

                        case "2":
                            Student.XuatDS(students);
                            break;

                        case "3":
                            Console.WriteLine("Danh sách học sinh có tuổi từ 15 đến 18:");
                            var students15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
                            foreach (Student student in students15to18)
                            {
                                student.Output();
                            }
                            break;

                        case "4":
                            Console.WriteLine("Danh sách học sinh có tên chính bắt đầu bằng chữ A:");
                            var studentsWithNameStartingWithA = students
                                .Where(s => Student.GetMainName(s.Name).StartsWith("A", StringComparison.OrdinalIgnoreCase))
                                .ToList();
                            foreach (Student student in studentsWithNameStartingWithA)
                            {
                                student.Output();
                            }
                            break;

                        case "5":
                            Student.Tongtuoi(students);
                            break;

                        case "6":
                            Student.HStuoiMax(students);
                            break;

                        case "7":
                            Student.DStuoitangdan(students);
                            break;

                        case "0":
                            exit = true;
                            Console.WriteLine("Kết thúc chương trình.");
                            break;

                        default:
                            Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                            break;
                    }
                }
            }
        }
    }
}
 