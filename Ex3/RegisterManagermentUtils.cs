﻿using System;

namespace L83Exercises3
{
    class RegisterManagermentUtils
    {
        // nhập thông tin bảng điểm cho các sinh viên trong lớp
        public void FillTranscript(Course[] courses, Student[] students)
        {
            var controller = new Controller();
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsCourseIdValid(courseIdString))
            {
                var message = "Mã lớp không hợp lệ.";
                throw new InvalidCourseIdException(message, courseIdString);
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                Student student = null;
                try
                {
                    student = FindStudentById(students);
                }
                catch (InvalidNameException e)
                {
                    Console.WriteLine(e);
                }
                if (student == null)
                {
                    return;
                }
                if (IsStudentExistedInCourse(course, student))
                {
                    Console.WriteLine("==> Lỗi. Bảng điểm của sinh viên này đã tồn tại. Hãy thử sinh viên khác. <==");
                }
                else if (student != null && course.NumberOfTranscript < course.NumberOfStudent)
                {
                    var transcripts = course.Transcripts;
                    Console.WriteLine("Nhập điểm hệ số 1: ");
                    var grade1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập điểm hệ số 2: ");
                    var grade2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập điểm hệ số 3: ");
                    var grade3 = float.Parse(Console.ReadLine());
                    transcripts[course.NumberOfTranscript] = new Transcript(0, student, grade1, grade2, grade3, 0);
                    transcripts[course.NumberOfTranscript].CalculateGpa();
                    course.NumberOfTranscript++;
                }
                else if (student == null)
                {
                    Console.WriteLine("==> Không tìm thấy sinh viên cần nhập điểm. <==");
                }
                else
                {
                    Console.WriteLine("==> Danh sách bảng điểm và sinh viên đã đầy <==");
                }
            }
            else
            {
                Console.WriteLine("==> Không tồn tại lớp học cần tìm. <==");
            }
        }

        // tìm xem bảng điểm của sinh viên x có trong lớp hiện tại chưa
        public bool IsStudentExistedInCourse(Course course, Student student)
        {
            foreach (var item in course.Transcripts)
            {
                if (item != null && item.Student.StudentId.CompareTo(student.StudentId) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // hiển thị danh sách sinh viên ra màn hình
        public void ShowStudents(Student[] students)
        {
            var dateFormat = "dd/MM/yyyy";
            var id = "Mã SV";
            var name = "Họ và tên";
            var birthDate = "Ngày sinh";
            var address = "Địa chỉ";
            var email = "Email";
            var phoneNumber = "Số điện thoại";
            var major = "Chuyên ngành";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{birthDate,-15:d}{address,-25:d}" +
                $"{email,-30:d}{phoneNumber,-15:d}{major:-20:d}");
            foreach (var student in students)
            {
                if (student != null)
                {
                    Console.WriteLine($"{student.StudentId,-15:d}{student.FullName,-25:d}" +
                        $"{student.BirthDate.ToString(dateFormat),-15:d}{student.Address,-25:d}" +
                        $"{student.Email,-30:d}{student.PhoneNumber,-15:d}{student.Major:-20:d}");
                }
                else
                {
                    break;
                }
            }
        }

        // hiển thị danh sách môn học ra màn hình
        public void ShowSubjects(Subject[] subjects)
        {
            var id = "Mã môn học";
            var name = "Tên môn học";
            var credit = "Số tín chỉ";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{credit,-15:d}");
            foreach (var subject in subjects)
            {
                if (subject != null)
                {
                    Console.WriteLine($"{subject.SubjectId,-15:d}{subject.SubjectName,-25:d}" +
                        $"{subject.Credit,-15:d}");
                }
                else
                {
                    break;
                }
            }
        }

        // hiển thị danh sách bảng điểm của từng lớp học ra màn hình
        public void ShowTranscript(Course[] courses)
        {
            var id = "Mã SV";
            var transId = "Mã bảng điểm";
            var name = "Họ tên sinh viên";
            var grade1 = "Điểm hệ số 1";
            var grade2 = "Điểm hệ số 2";
            var grade3 = "Điểm hệ số 3";
            var gpa = "Điểm TB";
            var dashedLine = "-----------------------------------------------" +
                             "-----------------------------------------------";
            Console.WriteLine(dashedLine);
            foreach (var item in courses)
            {
                if (item != null)
                {
                    Console.WriteLine($"Mã lớp: {item.CourseId}");
                    Console.WriteLine($"Giáo viên: {item.Teacher}");
                    Console.WriteLine($"Môn học: {item.Subject.SubjectName}");
                    Console.WriteLine($"Số sinh viên: {item.NumberOfStudent}");
                    if (item.NumberOfTranscript > 0)
                    {
                        Console.WriteLine($"{transId,-15:d}{id,-15:d}{name,-25:d}{grade1,-15:d}" +
                        $"{grade2,-15:d}{grade3,-15:d}{gpa,-15:d}");
                        foreach (var tran in item.Transcripts)
                        {
                            if (tran == null)
                            {
                                break;
                            }
                            Console.WriteLine($"{tran.TranscriptId,-15:d}{tran.Student.StudentId,-15:d}" +
                                $"{tran.Student.FullName,-25:d}" +
                                $"{tran.GradeLevel1 + "",-15:d}" + $"{tran.GradeLevel2 + "",-15:d}" +
                                $"{tran.GradeLevel3 + "",-15:d}{tran.Gpa + "",-15:d}");
                        }
                    }
                    Console.WriteLine(dashedLine);
                }
                else
                {
                    break;
                }
            }
        }

        // sắp xếp danh sách sinh viên theo tên a-z
        public void SortStudentsByName(Student[] students)
        {
            int comparer(Student s1, Student s2)
            {
                if (s1 == null && s2 == null)
                {
                    return 0;
                }
                else if (s1 == null && s2 != null)
                {
                    return 1;
                }
                else if (s1 != null && s2 == null)
                {
                    return -1;
                }
                else
                {
                    int nameCompare = s1.FullName.FirstName.CompareTo(s2.FullName.FirstName);
                    if (nameCompare != 0)
                    {
                        return nameCompare;
                    }
                    else
                    {
                        return s1.FullName.LastName.CompareTo(s2.FullName.LastName);
                    }
                }
            }
            Array.Sort(students, comparer);
        }

        // tìm sinh viên theo tên
        public Student FindStudentById(Student[] students)
        {
            var controller = new Controller();
            Console.WriteLine("Nhập mã sinh viên cần tìm: ");
            var studentId = Console.ReadLine().ToUpper();
            if (!controller.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ.";
                throw new InvalidStudentIdException(msg, studentId);
            }
            foreach (var item in students)
            {
                if (item == null)
                {
                    return null;
                }
                if (item.StudentId.CompareTo(studentId) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        // xóa sinh viên theo tên
        public void RemoveStudentById(Student[] students, ref int numOfStudent)
        {
            var controller = new Controller();
            var isFound = false;
            Console.WriteLine("Nhập mã sinh viên cần xóa: ");
            var studentId = Console.ReadLine();
            if (!controller.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ.";
                throw new InvalidStudentIdException(msg, studentId);
            }
            for (int i = 0; i < numOfStudent; i++)
            {
                var student = students[i];
                if (student.StudentId.CompareTo(studentId) == 0)
                {
                    isFound = true;
                    Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                    var ans = Console.ReadLine()[0];
                    if (ans == 'Y' || ans == 'y')
                    {
                        for (int j = i; j < numOfStudent; j++)
                        {
                            students[j] = students[j + 1];
                        }
                        numOfStudent--; // giảm số phần tử trong mảng sinh viên đi 1 đơn vị
                        Console.WriteLine($"==> Sinh viên mã \"{studentId}\" đã được xóa khỏi danh sách. <==");
                    }
                    else
                    {
                        Console.WriteLine("==> Hành động xóa sinh viên bị hủy bỏ. <==");
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("==> Không tìm thấy sinh viên cần xóa. <==");
            }
        }

        // sắp xếp bảng điểm theo điểm TB giảm dần
        public void SortTranscripts(Course[] courses)
        {
            int comparer(Transcript s1, Transcript s2)
            {
                if (s1 == null && s2 == null)
                {
                    return 0;
                }
                else if (s1 == null && s2 != null)
                {
                    return 1;
                }
                else if (s1 != null && s2 == null)
                {
                    return -1;
                }
                else
                {
                    if (s1.Gpa > s2.Gpa)
                    {
                        return -1;
                    }
                    else if (s1.Gpa == s2.Gpa)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i] != null)
                {
                    Array.Sort(courses[i].Transcripts, comparer);
                }
            }
        }

        // liệt kê danh sách sinh viên giỏi của từng lớp
        public void GoodStudents(Course[] courses)
        {
            bool isFound = false;
            Console.WriteLine("==> Các sinh viên giỏi của từng lớp: ");
            foreach (var item in courses)
            {
                if (item != null && item.NumberOfTranscript > 0)
                {
                    Console.WriteLine("Mã lớp: " + item.CourseId);
                    Console.WriteLine("Môn học: " + item.Subject.SubjectName);
                    Console.WriteLine("Người dạy: " + item.Teacher);
                    var id = "Mã sinh viên";
                    var name = "Họ và tên";
                    var gpa = "Điểm TB";
                    Console.WriteLine($"{id,-15:d}{name,-25:d}{gpa,-15:d}");
                    foreach (var tran in item.Transcripts)
                    {
                        if (tran != null && tran.Gpa >= 8.0f)
                        {
                            isFound = true;
                            Console.WriteLine($"{tran.Student.StudentId,-15:d}" +
                                $"{tran.Student.FullName,-25:d}{tran.Gpa + "",-15:d}");
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("==> Không có sinh viên giỏi. <==");
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("==> Không có kết quả. <==");
            }
        }

        // liệt kê danh sách sinh viên trượt môn
        public void FailedStudents(Course[] courses)
        {
            bool isFound = false;
            Console.WriteLine("==> Các sinh viên trượt môn của từng lớp: ");
            foreach (var item in courses)
            {
                if (item != null && item.NumberOfTranscript > 0)
                {
                    Console.WriteLine("Mã lớp: " + item.CourseId);
                    Console.WriteLine("Môn học: " + item.Subject.SubjectName);
                    Console.WriteLine("Người dạy: " + item.Teacher);
                    var id = "Mã sinh viên";
                    var name = "Họ và tên";
                    var gpa = "Điểm TB";
                    Console.WriteLine($"{id,-15:d}{name,-25:d}{gpa,-15:d}");
                    foreach (var tran in item.Transcripts)
                    {
                        if (tran != null && tran.Gpa < 4.0f)
                        {
                            isFound = true;
                            Console.WriteLine($"{tran.Student.StudentId,-15:d}" +
                                $"{tran.Student.FullName,-25:d}{tran.Gpa + "",-15:d}");
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("==> Không có sinh viên trượt môn. <==");
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("==> Không có kết quả. <==");
            }
        }

        // cập nhật điểm cho sinh viên
        public void UpdateGrade(Course[] courses)
        {
            var controller = new Controller();
            Console.WriteLine("Mã lớp: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsStudentIdValid(courseIdString))
            {
                var msg = "Mã lớp không hợp lệ.";
                throw new InvalidCourseIdException(msg, courseIdString);
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                Console.WriteLine("Mã sinh viên cần sửa điểm: ");
                var studentId = Console.ReadLine().ToUpper();
                if (!controller.IsStudentIdValid(studentId))
                {
                    var msg = "Mã sinh viên không hợp lệ.";
                    throw new InvalidStudentIdException(msg, studentId);
                }
                var isFound = false;
                for (int i = 0; i < course.Transcripts.Length; i++)
                {
                    if (course.Transcripts[i] == null)
                    {
                        break;
                    }
                    if (course.Transcripts[i].Student.StudentId.CompareTo(studentId) == 0)
                    {
                        isFound = true;
                        Console.WriteLine("Nhập điểm hệ số 1: ");
                        var grade1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Nhập điểm hệ số 2: ");
                        var grade2 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Nhập điểm hệ số 3: ");
                        var grade3 = float.Parse(Console.ReadLine());
                        course.Transcripts[i].GradeLevel1 = grade1;
                        course.Transcripts[i].GradeLevel2 = grade2;
                        course.Transcripts[i].GradeLevel3 = grade3;
                        course.Transcripts[i].CalculateGpa();
                        Console.WriteLine("==> Cập nhật thành công! <==");
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine("==> Không tồn tại sinh viên cần cập nhật điểm. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Không tồn tại lớp học cần tìm. <==");
            }
        }

        // tìm lớp học theo mã lớp
        public Course FindCourseById(Course[] courses, int courseId)
        {
            foreach (var item in courses)
            {
                if (item != null && item.CourseId == courseId)
                {
                    return item;
                }
            }
            return null;
        }

        // tìm sinh viên theo điểm TB
        public Transcript[] FindStudentByGpa(Course[] courses)
        {
            var controller = new Controller();
            Transcript[] result = new Transcript[courses.Length];
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsCourseIdValid(courseIdString))
            {
                var msg = "Mã lớp không hợp lệ.";
                throw new InvalidCourseIdException(msg, courseIdString);
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                var numOfResult = 0;
                Console.WriteLine("Nhập mức điểm cần tìm: ");
                var gpa = float.Parse(Console.ReadLine());
                var transcripts = course.Transcripts;
                foreach (var item in transcripts)
                {
                    if (item != null && item.Gpa >= gpa)
                    {
                        result[numOfResult++] = item;
                    }
                }
            }
            else
            {
                Console.WriteLine("==> Không tồn tại lớp học cần tìm. <==");
            }
            return result;
        }

        // xóa bảng điểm theo mã bảng điểm cho trước
        public void RemoveTranscript(Course[] courses)
        {
            var controller = new Controller();
            bool isFound = false;
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsCourseIdValid(courseIdString))
            {
                var msg = "Mã lớp không hợp lệ.";
                throw new InvalidCourseIdException(msg, courseIdString);
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                Console.WriteLine("Nhập mã bảng điểm cần xóa: ");
                var transIdString = Console.ReadLine();
                if (!controller.IsTranscriptIdValid(transIdString))
                {
                    var msg = "Mã bảng điểm không hợp lệ.";
                    throw new InvalidTranscriptIdException(msg, transIdString);
                }
                var transcriptId = int.Parse(transIdString);
                var transcripts = course.Transcripts;
                for (var i = 0; i < transcripts.Length; i++)
                {
                    var item = transcripts[i];
                    if (item != null && item.TranscriptId == transcriptId)
                    {
                        isFound = true;
                        Console.WriteLine("Bạn có chắc muốn xóa không?(Y/N):");
                        var ans = Console.ReadLine()[0];
                        if (ans == 'y' || ans == 'Y')
                        {
                            // chuyển các phần tử bên phải phần tử bị xóa sang trái 1 đơn vị
                            for (int j = i; j < transcripts.Length - 1; j++)
                            {
                                transcripts[j] = transcripts[j + 1];
                            }
                            // xóa phần tử cuối khác null khỏi danh sách bảng điểm
                            transcripts[course.NumberOfTranscript - 1] = null;
                            course.NumberOfTranscript--; // giảm số bảng điểm hiện có đi 1
                            Console.WriteLine("==> Xóa thành công. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Hành động xóa đã được hủy bỏ. <==");
                        }
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine("==> Không tìm thấy bảng điểm cần xóa. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Không tồn tại lớp học cần tìm. <==");
            }
        }

        // tạo mới đối tượng sinh viên
        public Student CreateStudent()
        {
            var controller = new Controller();
            Console.WriteLine("Họ và tên: ");
            var fullName = Console.ReadLine();
            if (!controller.IsFullNameValid(fullName))
            {
                var msg = "Họ và tên không hợp lệ. Họ tên hợp lệ chỉ chứa các chữ cái và dấu cách.";
                throw new InvalidNameException(msg, fullName);
            }
            Console.WriteLine("Địa chỉ: ");
            var address = Console.ReadLine();
            Console.WriteLine("Ngày sinh: ");
            var birthDate = Console.ReadLine();
            if (!controller.IsBirthdateValid(birthDate))
            {
                var msg = "Ngày sinh không hợp lệ. Ngày sinh hợp lệ dạng 01/01/2001.";
                throw new InvalidBirthDateException(msg, birthDate);
            }
            var dob = DateTime.ParseExact(birthDate, "dd/MM/yyyy", null);
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            if (!controller.IsEmailValid(email))
            {
                var msg = "Email không hợp lệ.";
                throw new InvalidEmailException(msg, email);
            }
            Console.WriteLine("Số điện thoại: ");
            var phoneNumber = Console.ReadLine();
            if (!controller.IsPhoneNumberValid(phoneNumber))
            {
                var msg = "Số điện thoại không hợp lệ.";
                throw new InvalidPhoneNumberException(msg, phoneNumber);
            }
            Console.WriteLine("Chuyên ngành: ");
            var major = Console.ReadLine();
            return new Student(fullName, address, dob, email, phoneNumber, null, major);
        }

        // tạo mới đối tượng môn học
        public Subject CreateSubject()
        {
            Console.WriteLine("Tên môn học: ");
            var subjectName = Console.ReadLine();
            Console.WriteLine("Số tín chỉ: ");
            var credit = int.Parse(Console.ReadLine());
            return new Subject(0, subjectName, credit);
        }

        // tạo mới đối tượng lớp học phần
        public Course CreateCourse(Subject[] subjects)
        {
            var controller = new Controller();
            Console.WriteLine("Mã môn học: ");
            var subjectIdString = Console.ReadLine();
            if (!controller.IsSubjectIdValid(subjectIdString))
            {
                var msg = "Mã môn học không đúng định dạng.";
                throw new InvalidSubjectIdException(msg, subjectIdString);
            }
            var subjectId = int.Parse(subjectIdString);
            var subject = FindSubjectById(subjects, subjectId);
            if (subject == null)
            {
                return null;
            }
            Console.WriteLine("Số lượng sinh viên: ");
            var numOfStudent = int.Parse(Console.ReadLine());
            Console.WriteLine("Người dạy: ");
            var teacher = Console.ReadLine();
            return new Course(0, subject, teacher, numOfStudent);
        }

        // tìm môn học theo mã môn học cho trước
        public Subject FindSubjectById(Subject[] subjects, int id)
        {
            foreach (var item in subjects)
            {
                if (item == null)
                {
                    return null;
                }
                if (item.SubjectId == id)
                {
                    return item;
                }
            }
            return null;
        }

        // tạo danh sách khóa học fake
        public void CreateFakeCourses(Course[] courses, ref int numOfCourse, Subject[] subjects)
        {
            courses[numOfCourse++] = new Course(0, subjects[0], "Ngô Quang Đại", 50);
            courses[numOfCourse++] = new Course(0, subjects[2], "Ngô Quang Đại", 50);
            courses[numOfCourse++] = new Course(0, subjects[1], "Lê Thu Hà", 40);
            courses[numOfCourse++] = new Course(0, subjects[2], "Hoàng Việt Cường", 50);
            courses[numOfCourse++] = new Course(0, subjects[2], "Ma Quốc Chuyên", 45);
            courses[numOfCourse++] = new Course(0, subjects[3], "Nguyễn Văn Vĩnh", 40);
            courses[numOfCourse++] = new Course(0, subjects[1], "Trần Văn Vinh", 60);
            courses[numOfCourse++] = new Course(0, subjects[1], "Trần Văn Vinh", 50);
        }

        // tạo danh sách môn học fake
        public void CreateFakeSubjects(Subject[] subjects, ref int numOfSubject)
        {
            subjects[numOfSubject++] = new Subject(0, "C++", 3);
            subjects[numOfSubject++] = new Subject(0, "C#", 4);
            subjects[numOfSubject++] = new Subject(0, "Java", 4);
            subjects[numOfSubject++] = new Subject(0, "Python", 4);
            subjects[numOfSubject++] = new Subject(0, "Data struct", 3);
            subjects[numOfSubject++] = new Subject(0, "Android", 5);
            subjects[numOfSubject++] = new Subject(0, "Kotlin", 3);
            subjects[numOfSubject++] = new Subject(0, "SQL", 3);
            subjects[numOfSubject++] = new Subject(0, "JavaScript", 3);
        }

        // tạo danh sách sinh viên fake
        public void CreateFakeStudents(Student[] students, ref int numOfStudent)
        {
            var dateFormat = "dd/MM/yyyy";
            students[numOfStudent++] = new Student("Trần Anh Tuấn", "Hà Nội", DateTime.ParseExact("12/02/2007", dateFormat, null), "anhtuan@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Ngô Nhật Nam", "Lào Cai", DateTime.ParseExact("18/03/2007", dateFormat, null), "nhatnam@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Hoàng Trọng Nhân", "Đà Nẵng", DateTime.ParseExact("11/04/2007", dateFormat, null), "trongnhan@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Lê Quốc Cường", "Hồ Chí Minh", DateTime.ParseExact("14/05/2007", dateFormat, null), "quoccuong@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Nguyễn Thị Thoa", "Quảng Nam", DateTime.ParseExact("15/06/2007", dateFormat, null), "thoanguyen@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Lại Viết Hòa", "Bình Dương", DateTime.ParseExact("19/07/2007", dateFormat, null), "viethoa@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Ma Thùy Linh", "Hà Nội", DateTime.ParseExact("20/08/2007", dateFormat, null), "thuylinh@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Ngô Công Chất", "Nghệ An", DateTime.ParseExact("18/09/2007", dateFormat, null), "congchatct@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Lê Công Tuấn", "Thanh Hóa", DateTime.ParseExact("22/10/2007", dateFormat, null), "congtuanct@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Trần Văn Bách", "Hà Nam", DateTime.ParseExact("25/11/2007", dateFormat, null), "vanbachvv@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Nguyễn Hữu Thắng", "Hà Nội", DateTime.ParseExact("17/12/2007", dateFormat, null), "huythang@xmail.com", "0972135975", null, "CNTT");
            students[numOfStudent++] = new Student("Nguyễn Thu Hà", "Quảng Ninh", DateTime.ParseExact("18/05/2007", dateFormat, null), "thuhacute@xmail.com", "0972135975", null, "CNTT");
        }
    }
}
