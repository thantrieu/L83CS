﻿namespace L83Exercises2
{
    // lớp mô tả thông tin môn học
    class Subject
    {
        private static int autoId = 10001;
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int NumOfLesson { get; set; }

        public Subject() { }

        public Subject(int id)
        {
            if (id == 0)
            {
                SubjectId = autoId++;
            }
            else
            {
                SubjectId = id;
            }
        }

        public Subject(int id, string name, int credit, int lesson) : this(id)
        {
            Name = name;
            Credit = credit;
            NumOfLesson = lesson;
        }

        public override bool Equals(object obj)
        {
            return obj is Subject subject &&
                   SubjectId == subject.SubjectId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
