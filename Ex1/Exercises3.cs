/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.24</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExercisesLesson71
{
    class Exercises3
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Subject[] subjects = new Subject[100];
            Student[] students = new Student[100];
            Course[] courses = new Course[100];
            int numOfCourse = 0; // số lượng các lớp học
            int numOfStudent = 0; // số lượng các sinh viên
            int numOfSubject = 0; // số lượng các môn học
            CreateFakeStudents(students, ref numOfStudent);
            CreateFakeSubjects(subjects, ref numOfSubject);
            CreateFakeCourses(courses, ref numOfCourse, subjects);

            int choice;
            do
            {
                Console.WriteLine("=========================== CÁC CHỨC NĂNG ============================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách.                           *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách.                             *");
                Console.WriteLine("*    03. Thêm mới lớp học phần vào danh sách.                        *");
                Console.WriteLine("*    04. Nhập bảng điểm cho sinh viên trong một lớp.                 *");
                Console.WriteLine("*    05. Hiển thị danh sách sinh viên ra màn hình.                   *");
                Console.WriteLine("*    06. Hiển thị danh sách môn học ra màn hình.                     *");
                Console.WriteLine("*    07. Hiển thị danh sách bảng điểm của từng lớp học phần.         *");
                Console.WriteLine("*    08. Sắp xếp danh sách sinh viên theo tên tăng dần.              *");
                Console.WriteLine("*    09. Tìm sinh viên theo mã sinh viên cho trước.                  *");
                Console.WriteLine("*    10. Xóa sinh viên theo mã cho trước khỏi danh sách.             *");
                Console.WriteLine("*    11. Sắp xếp danh sách bảng điểm của một lớp học phần.           *");
                Console.WriteLine("*    12. Liệt kê số lượng các sinh viên có điểm TB loại giỏi.        *");
                Console.WriteLine("*    13. Liệt kê số lượng sinh viên trượt môn trong từng lớp.        *");
                Console.WriteLine("*    14. Sửa điểm cho sinh viên theo mã lớp và mã sinh viên.         *");
                Console.WriteLine("*    15. Tìm các sinh viên có điểm TB >= x nhập vào từ bàn phím.     *");
                Console.WriteLine("*    16. Xóa bảng điểm của sinh viên x trong lớp học phần p nào đó.  *");
                Console.WriteLine("*    17. Thoát chương trình.                                         *");
                Console.WriteLine("==================================================================");
                Console.WriteLine("==> Xin mời bạn chọn 1 chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var newStudent = CreateStudent();
                        if (newStudent != null)
                        {
                            students[numOfStudent++] = newStudent;
                            Console.WriteLine("==> Thêm sinh viên thành công.");
                        }
                        else
                        {
                            Console.WriteLine("==> Thêm sinh viên thất bại.");
                        }
                        break;
                    case 2:
                        var subject = CreateSubject();
                        if (subject != null)
                        {
                            subjects[numOfSubject++] = subject;
                        }
                        break;
                    case 3:
                        var course = CreateCourse(subjects);
                        if (course != null)
                        {
                            courses[numOfCourse++] = course;
                        }
                        break;
                    case 4:
                        if (numOfCourse > 0)
                        {
                            FillTranscript(courses, students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 5:
                        if (numOfCourse > 0)
                        {
                            ShowStudents(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 6:
                        if (numOfCourse > 0)
                        {
                            ShowSubjects(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 7:
                        if (numOfCourse > 0)
                        {
                            ShowTranscript(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 8:
                        if (numOfCourse > 0)
                        {
                            SortStudentsByName(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 9:
                        if (numOfCourse > 0)
                        {
                            var student = FindStudentById(students);
                            if (student != null)
                            {
                                Console.WriteLine("==> Sinh viên cần tìm: <==");
                                ShowStudents(new Student[] { student });
                            }
                            else
                            {
                                Console.WriteLine("==> Không tìm thấy sinh viên cần tìm. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 10:
                        if (numOfCourse > 0)
                        {
                            RemoveStudentById(students, ref numOfStudent);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 11:
                        if (numOfCourse > 0)
                        {
                            SortTranscripts(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 12:
                        if (numOfCourse > 0)
                        {
                            GoodStudents(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 13:
                        if (numOfCourse > 0)
                        {
                            FailedStudents(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 14:
                        if (numOfCourse > 0)
                        {
                            UpdateGrade(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 15:
                        if (numOfCourse > 0)
                        {
                            var result = FindStudentByGpa(courses);
                            if (result != null && result[0] != null)
                            {
                                Console.WriteLine("==> Kết quả tìm kiếm: <==");
                                foreach (var item in result)
                                {
                                    if (item != null)
                                    {
                                        Console.WriteLine($"{item.Student.StudentId,-15:d}" +
                                            $"{item.Student.FullName,-25:d}{item.Gpa + "",-15:d}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 16:
                        if (numOfCourse > 0)
                        {
                            RemoveTranscript(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 17:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 17);
        }

        // nhập thông tin bảng điểm cho các sinh viên trong lớp
        private static void FillTranscript(Course[] courses, Student[] students)
        {
            var controller = new Controller();
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if(!controller.IsCourseIdValid(courseIdString))
            {
                Console.WriteLine("==> Mã lớp không hợp lệ. Mã lớp hợp lệ phải có 5 chữ số.");
                return;
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                var student = FindStudentById(students);
                if(student == null)
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
        private static bool IsStudentExistedInCourse(Course course, Student student)
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
        private static void ShowStudents(Student[] students)
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
        private static void ShowSubjects(Subject[] subjects)
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
        private static void ShowTranscript(Course[] courses)
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
        private static void SortStudentsByName(Student[] students)
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
        private static Student FindStudentById(Student[] students)
        {
            var controller = new Controller();
            Console.WriteLine("Nhập mã sinh viên cần tìm: ");
            var studentId = Console.ReadLine().ToUpper();
            if(!controller.IsStudentIdValid(studentId))
            {
                Console.WriteLine("==> Mã sinh viên không hợp lệ.");
                return null;
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
        private static void RemoveStudentById(Student[] students, ref int numOfStudent)
        {
            var controller = new Controller();
            var isFound = false;
            Console.WriteLine("Nhập mã sinh viên cần xóa: ");
            var studentId = Console.ReadLine();
            if(!controller.IsStudentIdValid(studentId))
            {
                Console.WriteLine("==> Mã sinh viên không hợp lệ.");
                return;
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
        private static void SortTranscripts(Course[] courses)
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
        private static void GoodStudents(Course[] courses)
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
        private static void FailedStudents(Course[] courses)
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
        private static void UpdateGrade(Course[] courses)
        {
            var controller = new Controller();
            Console.WriteLine("Mã lớp: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsStudentIdValid(courseIdString))
            {
                Console.WriteLine("==> Mã lớp không hợp lệ. Cập nhật thất bại.");
                return;
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                Console.WriteLine("Mã sinh viên cần sửa điểm: ");
                var studentId = Console.ReadLine().ToUpper();
                if (!controller.IsStudentIdValid(studentId))
                {
                    Console.WriteLine("==> Mã sinh viên không hợp lệ. Cập nhật thất bại.");
                    return;
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
        private static Course FindCourseById(Course[] courses, int courseId)
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
        private static Transcript[] FindStudentByGpa(Course[] courses)
        {
            var controller = new Controller();
            Transcript[] result = new Transcript[courses.Length];
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if (!controller.IsCourseIdValid(courseIdString))
            {
                Console.WriteLine("==> Mã lớp không hợp lệ. ");
                return null;
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
        private static void RemoveTranscript(Course[] courses)
        {
            var controller = new Controller();
            bool isFound = false;
            Console.WriteLine("Mã lớp cần tìm: ");
            var courseIdString = Console.ReadLine();
            if(!controller.IsCourseIdValid(courseIdString))
            {
                Console.WriteLine("==> Mã lớp không hợp lệ. ");
                return;
            }
            var courseId = int.Parse(courseIdString);
            var course = FindCourseById(courses, courseId);
            if (course != null)
            {
                Console.WriteLine("Nhập mã bảng điểm cần xóa: ");
                var transIdString = Console.ReadLine();
                if (!controller.IsTranscriptIdValid(transIdString))
                {
                    Console.WriteLine("==> Mã bảng điểm không hợp lệ. ");
                    return;
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
        private static Student CreateStudent()
        {
            var controller = new Controller();
            Console.WriteLine("Họ và tên: ");
            var fullName = Console.ReadLine();
            if(!controller.IsFullNameValid(fullName))
            {
                Console.WriteLine("==> Họ và tên không hợp lệ. Họ tên hợp lệ chỉ chứa các chữ cái và dấu cách.");
                return null;
            }
            Console.WriteLine("Địa chỉ: ");
            var address = Console.ReadLine();
            Console.WriteLine("Ngày sinh: ");
            var birthDate = Console.ReadLine();
            if (!controller.IsBirthdateValid(birthDate))
            {
                Console.WriteLine("==> Họ và tên không hợp lệ. Ngày sinh hợp lệ dạng 01/01/2001.");
                return null;
            }
            var dob = DateTime.ParseExact(birthDate, "dd/MM/yyyy", null);
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            if (!controller.IsEmailValid(email))
            {
                Console.WriteLine("==> Email không hợp lệ. Vui lòng kiểm tra lại email.");
                return null;
            }
            Console.WriteLine("Số điện thoại: ");
            var phoneNumber = Console.ReadLine();
            if (!controller.IsPhoneNumberValid(phoneNumber))
            {
                Console.WriteLine("==> Số điện thoại không hợp lệ. Vui lòng kiểm tra lại số điện thoại.");
                return null;
            }
            Console.WriteLine("Chuyên ngành: ");
            var major = Console.ReadLine();
            return new Student(fullName, address, dob, email, phoneNumber, null, major);
        }

        // tạo mới đối tượng môn học
        private static Subject CreateSubject()
        {
            Console.WriteLine("Tên môn học: ");
            var subjectName = Console.ReadLine();
            Console.WriteLine("Số tín chỉ: ");
            var credit = int.Parse(Console.ReadLine());
            return new Subject(0, subjectName, credit);
        }

        // tạo mới đối tượng lớp học phần
        private static Course CreateCourse(Subject[] subjects)
        {
            var controller = new Controller();
            Console.WriteLine("Mã môn học: ");
            var subjectIdString  = Console.ReadLine();
            if (!controller.IsSubjectIdValid(subjectIdString))
            {
                Console.WriteLine("==> Mã môn học không đúng.");
                return  null;
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
        private static Subject FindSubjectById(Subject[] subjects, int id)
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
        private static void CreateFakeCourses(Course[] courses, ref int numOfCourse, Subject[] subjects)
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
        private static void CreateFakeSubjects(Subject[] subjects, ref int numOfSubject)
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
        private static void CreateFakeStudents(Student[] students, ref int numOfStudent)
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

    // lớp mô tả thông tin người
    class Person
    {
        public FullName FullName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Person() { }
        public Person(string fullName, string address,
            DateTime birthDate, string email, string phoneNumber)
        {
            FullName = new FullName(fullName);
            Address = address;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    // lớp mô tả thông tin họ và tên
    class FullName
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MidName { get; set; } = "";

        public FullName() { }

        public FullName(string fullName)
        {
            SetFullName(fullName);
        }

        public FullName(string firstName, string lastName, string midName)
        {
            FirstName = firstName;
            LastName = lastName;
            MidName = midName;
        }

        public void SetFullName(string fullName)
        {
            var data = fullName.Split(' ');
            LastName = data[0];
            FirstName = data[data.Length - 1];
            var mid = "";
            for (int i = 1; i < data.Length - 1; i++)
            {
                mid += data[i] + " ";
            }
            MidName = mid.Trim();
        }

        public override string ToString()
        {
            return $"{LastName} {MidName} {FirstName}";
        }
    }

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

    // lớp mô tả thông tin môn học
    class Subject
    {
        private static int autoId = 1000;
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credit { get; set; }
        public Subject() { }

        public Subject(int id)
        {
            SubjectId = id == 0 ? autoId++ : id;
        }

        public Subject(int id, string name, int credit) : this(id)
        {
            SubjectName = name;
            Credit = credit;
        }
    }

    // lớp mô tả thông tin lớp học phần
    class Course
    {
        private static int autoId = 10000;
        public int CourseId { get; set; }
        public Subject Subject { get; set; }
        public string Teacher { get; set; } // người dạy
        public int NumberOfStudent { get; set; }
        public int NumberOfTranscript { get; set; }
        public Transcript[] Transcripts { get; set; }

        public Course() { }

        public Course(int id)
        {
            CourseId = id == 0 ? autoId++ : id;
        }

        public Course(int id, Subject subject, string teacher, int numberOfStudent) : this(id)
        {
            Teacher = teacher;
            Subject = subject;
            NumberOfStudent = numberOfStudent;
            Transcripts = new Transcript[numberOfStudent];
            NumberOfTranscript = 0;
        }
    }

    // lớp mô tả thông tin bảng điểm
    class Transcript
    {
        private int autoId = 1000;
        public int TranscriptId { get; set; }
        public Student Student { get; set; }
        public float GradeLevel1 { get; set; }
        public float GradeLevel2 { get; set; }
        public float GradeLevel3 { get; set; }
        public float Gpa { get; set; }

        public Transcript() { }

        public Transcript(int id)
        {
            TranscriptId = id == 0 ? autoId++ : id;
        }

        public Transcript(int id, Student s, float g1, float g2, float g3, float g4) : this(id)
        {
            Student = s;
            GradeLevel1 = g1;
            GradeLevel2 = g2;
            GradeLevel3 = g3;
            Gpa = g4;
        }

        public void CalculateGpa()
        {
            var gpa = 0.1f * GradeLevel1 + 0.3f * GradeLevel2 + 0.6f * GradeLevel3;
            Gpa = (float)Math.Round(gpa, 2);
        }
    }

    interface Icontroller
    {
        // kiểm tra định dạng mã sinh viên
        bool IsStudentIdValid(string studentId);
        // kiểm tra định dạng họ và tên
        bool IsFullNameValid(string fullName);
        // kiểm tra định dạng email
        bool IsEmailValid(string email);
        // kiểm tra định dạng số điện thoại
        bool IsPhoneNumberValid(string phoneNumber);
        // kiểm tra định dạng của mã môn học
        bool IsSubjectIdValid(string subjectId);
        // kiểm tra định dạng của mã lớp học phần
        bool IsCourseIdValid(string courseId);
        // kiểm tra định dạng của mã bảng điểm
        bool IsTranscriptIdValid(string transcriptId);
        // kiểm tra dịnh dạng ngày sinh có hợp lệ không
        bool IsBirthdateValid(string birthdate);
    }

    class Controller : Icontroller
    {
        public bool IsBirthdateValid(string birthdate)
        {
            var pattern = @"^\d{2}/\d{2}/\d{4}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(birthdate);
        }

        public bool IsCourseIdValid(string courseId)
        {
            var pattern = @"^\d{5}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(courseId))
            {
                var value = int.Parse(courseId);
                return value >= 10000;
            }
            return false;
        }

        public bool IsEmailValid(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z0-9-_.]*@[a-z0-9]+\.[a-z]{2,4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool IsFullNameValid(string fullName)
        {
            var pattern = @"^[a-z]+[a-z ]*$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(fullName);
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            var pattern = @"^(03|08|09)\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public bool IsStudentIdValid(string studentId)
        {
            var pattern = @"^ST\d{4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(studentId);
        }

        public bool IsSubjectIdValid(string subjectId)
        {
            var pattern = @"^\d{4}$";
            var regex = new Regex(pattern);
            if (regex.IsMatch(subjectId))
            {
                var value = int.Parse(subjectId);
                return value >= 1000;
            }
            return false;
        }

        public bool IsTranscriptIdValid(string transcriptId)
        {
            var pattern = @"^\d{4}$";
            var regex = new Regex(pattern);
            if (regex.IsMatch(transcriptId))
            {
                var value = int.Parse(transcriptId);
                return value >= 1000;
            }
            return false;
        }
    }
}
