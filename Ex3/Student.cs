using System;

namespace L83Exercises3
{
    // lớp mô tả thông tin sinh viên
    class Student : Person
    {
        private static int autoId = 1000;

        public string StudentId { get; set; }
        public string Major { get; set; }

        public Student() { }
        public Student(string studentId)
        {
            StudentId = studentId;
        }

        public Student(string fullName, string address,
             DateTime birthDate, string email, string phoneNumber,
            string studentId, string major) :
            base(fullName, address, birthDate, email, phoneNumber)
        {
            FullName = new FullName(fullName);
            Major = major;
            Address = address;
            StudentId = studentId == null ? $"ST{autoId++}" : studentId;
            Major = major;
        }
    }
}
