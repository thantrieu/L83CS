using System;

namespace L83Exercises2
{
    class StudentManagermentUtils
    {
        // tạo thông tin đăng ký fake
        public void CreateFakeRegisters(Register[] registers,
            ref int numOfRegister, Student[] students, Subject[] subjects)
        {
            registers[numOfRegister++] = new Register(0, students[0], subjects[0], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[1], subjects[0], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[2], subjects[0], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[3], subjects[0], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[4], subjects[0], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[0], subjects[5], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[1], subjects[2], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[2], subjects[1], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[3], subjects[3], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[4], subjects[4], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[1], subjects[1], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[1], subjects[5], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[0], subjects[1], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[0], subjects[2], DateTime.Now);
            registers[numOfRegister++] = new Register(0, students[0], subjects[3], DateTime.Now);
        }

        // kiểm tra xem một bản đăng ký đã tồn tại trước đó chưa
        public bool Contains(Register[] registers, Register newRegister)
        {
            foreach (var item in registers)
            {
                if (item != null && item.Equals(newRegister))
                {
                    return true;
                }
            }
            return false;
        }

        // tạo thông tin môn học fake
        public void CreateFakeSubjects(Subject[] subjects, ref int numOfSubject)
        {
            subjects[numOfSubject++] = new Subject(0, "C++", 3, 36);
            subjects[numOfSubject++] = new Subject(0, "C", 3, 36);
            subjects[numOfSubject++] = new Subject(0, "C#", 4, 48);
            subjects[numOfSubject++] = new Subject(0, "Java", 4, 46);
            subjects[numOfSubject++] = new Subject(0, "Kotlin", 3, 36);
            subjects[numOfSubject++] = new Subject(0, "Android", 5, 60);
            subjects[numOfSubject++] = new Subject(0, "SQL", 3, 36);
            subjects[numOfSubject++] = new Subject(0, "Python", 4, 48);
            subjects[numOfSubject++] = new Subject(0, "JavaScript", 3, 36);
            subjects[numOfSubject++] = new Subject(0, "Web design", 2, 25);
        }

        // tạo danh sách sinh viên fake
        public void CreateFakeStudents(Student[] students, ref int numOfStudent)
        {
            var dateFormat = "dd/MM/yyyy";
            students[numOfStudent++] = new Student("B25DCCN101", "Trần Văn Nam", DateTime.ParseExact("15/06/2007", dateFormat, null), "vannam@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN103", "Ngô Văn Tài", DateTime.ParseExact("15/04/2007", dateFormat, null), "vantai123@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN102", "Hồ Hoàng Yến", DateTime.ParseExact("27/07/2007", dateFormat, null), "hoangyenkk@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN105", "Võ Hoàng Yến", DateTime.ParseExact("11/09/2007", dateFormat, null), "yenvo@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN104", "Vy Thị Yến", DateTime.ParseExact("14/02/2007", dateFormat, null), "yenvi@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN108", "Mai Văn Dũng", DateTime.ParseExact("19/08/2007", dateFormat, null), "vandung@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN107", "Lê Thanh Thảo", DateTime.ParseExact("18/09/2007", dateFormat, null), "thanhthao@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN106", "Ngô Nhật Phong", DateTime.ParseExact("10/10/2007", dateFormat, null), "nhatphong@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN109", "Ma Thanh Thức", DateTime.ParseExact("16/11/2007", dateFormat, null), "thanhthuc@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN111", "Khúc Thị Lệ Quyên", DateTime.ParseExact("18/12/2007", dateFormat, null), "lequyenkhuc@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN110", "Trương Trọng Anh", DateTime.ParseExact("17/05/2007", dateFormat, null), "tronganhtruong@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN112", "Nguyễn Quỳnh Anh", DateTime.ParseExact("25/01/2007", dateFormat, null), "quynhanhng@xmail.com", "0912365211", "CNTT");
            students[numOfStudent++] = new Student("B25DCCN115", "Thân Văn Huấn", DateTime.ParseExact("30/04/2007", dateFormat, null), "vanhuanth@xmail.com", "0912365211", "CNTT");
        }

        // tìm bản đăng ký theo mã môn học
        public Register[] FindRegisterBySubjectId(Register[] registers)
        {
            var result = new Register[registers.Length];
            int numOfResult = 0;
            Console.WriteLine("Mã môn học cần tìm: ");
            var subjectId = int.Parse(Console.ReadLine());
            foreach (var item in registers)
            {
                if (item == null)
                {
                    break;
                }
                if (item.Subject.SubjectId == subjectId)
                {
                    result[numOfResult++] = item;
                }
            }
            return result;
        }

        // tạo mới bản đăng ký
        public Register CreateRegister(Student[] students, Subject[] subjects)
        {
            Console.WriteLine("Mã sinh viên đăng ký: ");
            var studentId = Console.ReadLine().ToUpper();
            Console.WriteLine("Mã môn học được chọn: ");
            var subjectId = int.Parse(Console.ReadLine());
            var registerTime = DateTime.Now;
            var studentIndex = FindStudentIndexById(students, studentId, students.Length);
            var subjectIndex = FindSubjectIndexById(subjects, subjectId, subjects.Length);
            var subject = subjectIndex == -1 ? null : subjects[subjectIndex];
            var student = studentIndex == -1 ? null : students[studentIndex];
            return new Register(0, student, subject, registerTime);
        }

        // tạo mới môn học
        public Subject CreateSubject()
        {
            Console.WriteLine("Tên môn học: ");
            var name = Console.ReadLine();
            Console.WriteLine("Số tín chỉ: ");
            var credit = int.Parse(Console.ReadLine());
            Console.WriteLine("Số tiết học: ");
            var lesson = int.Parse(Console.ReadLine());
            return new Subject(0, name, credit, lesson);
        }

        // tạo mới sinh viên
        public Student CreateStudent(Student[] students)
        {
            var filter = new Filter();
            Console.WriteLine("Mã sinh viên dạng B25DCCN001: ");
            var studentId = Console.ReadLine().ToUpper().Trim();
            if (!filter.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ.";
                throw new InvalidStudentIdException(msg, studentId);
            }
            else
            {
                // kiểm tra xem sinh viên với mã vừa nhập có trong danh sách chưa
                // nếu có rồi thì bỏ qua, nếu chưa thì cho tạo mới thông tin
                var indexOfStudent = FindStudentIndexById(students, studentId, students.Length);
                if (indexOfStudent >= 0)
                {
                    Console.WriteLine($"==> Sinh viên mã \"{studentId}\" đã tồn tại.");
                    return null;
                }
            }
            Console.WriteLine("Họ và tên: ");
            var name = Console.ReadLine().Trim();
            if (!filter.IsNameValid(name))
            {
                var msg = "Họ và tên không hợp lệ.";
                throw new InvalidNameException(msg, name);
            }
            Console.WriteLine("Ngày sinh dạng 01/01/2001: ");
            var birthDate = Console.ReadLine().Trim();
            if (!filter.IsBirthDateValid(birthDate))
            {
                var msg = "Ngày sinh không hợp lệ.";
                throw new InvalidBirthDateException(msg, birthDate);
            }
            var dateFormat = "dd/MM/yyyy";
            DateTime dob = DateTime.ParseExact(birthDate, dateFormat, null);

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            if (!filter.IsEmailValid(email))
            {
                var msg = "Email không hợp lệ.";
                throw new InvalidEmailException(msg, email);
            }
            Console.WriteLine("Số điện thoại: ");
            var phoneNumber = Console.ReadLine();
            if (!filter.IsPhoneValid(phoneNumber))
            {
                var msg = "Số điện thoại không hợp lệ.";
                throw new InvalidPhoneNumberException(msg, phoneNumber);
            }
            Console.WriteLine("Chuyên ngành: ");
            var major = Console.ReadLine();
            return new Student(studentId, name, dob, email, phoneNumber, major);
        }

        // hiển thị danh sách sinh viên
        public void ShowStudents(Student[] students)
        {
            var dateFormat = "dd/MM/yyyy";
            var id = "Mã sinh viên";
            var birthDate = "Ngày sinh";
            var email = "Email";
            var phoneNumber = "Số điện thoại";
            var name = "Họ và tên";
            var major = "Chuyên ngành";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{birthDate,-15:d}" +
                $"{email,-30:d}{phoneNumber,-15:d}{major,-15:d}");
            foreach (var student in students)
            {
                if (student == null)
                {
                    break;
                }
                Console.WriteLine($"{student.StudentId,-15:d}{student.FullName,-25:d}" +
                    $"{student.BirthDate.ToString(dateFormat),-15:d}{student.Email,-30:d}" +
                    $"{student.PhoneNumber,-15:d}{student.Major,-15:d}");
            }
        }

        // hiển thị danh sách đăng ký
        public void ShowRegisters(Register[] registers)
        {
            var id = "Mã đăng ký";
            var stId = "Mã sinh viên";
            var stName = "Tên sinh viên";
            var suId = "Mã môn học";
            var suName = "Tên môn học";
            var regTime = "Thời gian đăng ký";
            Console.WriteLine($"{id,-15:d}{stId,-15:d}{stName,-25:d}{suId,-15:d}{suName,-25:d}{regTime,-15:d}");
            foreach (var reg in registers)
            {
                if (reg == null)
                {
                    break;
                }
                Console.WriteLine($"{reg.RegisterId,-15:d}{reg.Student.StudentId,-15:d}" +
                    $"{reg.Student.FullName,-25:d}{reg.Subject.SubjectId,-15:d}" +
                    $"{reg.Subject.Name,-25:d}{reg.RegisterTime.ToString("dd/MM/yyyy HH:mm:ss"),-15:d}");
            }
        }

        // hiển thị danh sách môn học
        public void ShowSubjects(Subject[] subjects)
        {
            var id = "Mã môn học";
            var name = "Tên môn học";
            var credit = "Số tín chỉ";
            var lesson = "Số tiết học";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{credit,-15:d}{lesson,-15:d}");
            foreach (var subject in subjects)
            {
                if (subject == null)
                {
                    break;
                }
                Console.WriteLine($"{subject.SubjectId,-15:d}{subject.Name,-25:d}" +
                    $"{subject.Credit,-15:d}{subject.NumOfLesson,-15:d}");
            }
        }

        // sắp xếp danh sách sinh viên theo tên, nếu trùng tên thì sắp xếp theo họ a-z
        public void SortStudentByName(Student[] students)
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

        // sắp xếp danh sách môn học theo số tín chỉ
        public void SortSubjectByCredit(Subject[] subjects)
        {
            int comparer(Subject s1, Subject s2)
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
                    return s2.Credit - s1.Credit;
                }
            }
            Array.Sort(subjects, comparer);
        }

        // sắp xếp danh sách đăng ký theo thời gian đăng ký
        public void SortRegistersByRegTime(Register[] registers)
        {
            int comparer(Register r1, Register r2)
            {
                if (r1 == null && r2 == null)
                {
                    return 0;
                }
                else if (r1 == null && r2 != null)
                {
                    return 1;
                }
                else if (r1 != null && r2 == null)
                {
                    return -1;
                }
                else
                {
                    return r1.RegisterTime < r2.RegisterTime ? -1 :
                        r1.RegisterTime > r2.RegisterTime ? 1 : 0;
                }
            }
            Array.Sort(registers, comparer);
        }

        // sắp xếp danh sách đăng ký theo mã sinh viên
        public void SortRegistersByStudentId(Register[] registers)
        {
            int comparer(Register r1, Register r2)
            {
                if (r1 == null && r2 == null)
                {
                    return 0;
                }
                else if (r1 == null && r2 != null)
                {
                    return 1;
                }
                else if (r1 != null && r2 == null)
                {
                    return -1;
                }
                else
                {
                    return r1.Student.StudentId.CompareTo(r2.Student.StudentId);
                }
            }
            Array.Sort(registers, comparer);
        }

        // sắp xếp danh sách đăng ký theo mã môn học
        public void SortRegistersBySubjectId(Register[] registers)
        {
            int comparer(Register r1, Register r2)
            {
                if (r1 == null && r2 == null)
                {
                    return 0;
                }
                else if (r1 == null && r2 != null)
                {
                    return 1;
                }
                else if (r1 != null && r2 == null)
                {
                    return -1;
                }
                else
                {
                    return r1.Subject.SubjectId.CompareTo(r2.Subject.SubjectId);
                }
            }
            Array.Sort(registers, comparer);
        }

        // tìm bản đăng ký theo mã sinh viên
        public Register[] FindRegisterByStudentId(Register[] registers)
        {
            var result = new Register[registers.Length];
            int numOfResult = 0;
            Console.WriteLine("Mã sinh viên cần tìm: ");
            var studentId = Console.ReadLine().ToUpper();
            var filter = new Filter();
            if(!filter.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(msg, studentId);
            }
            foreach (var item in registers)
            {
                if (item == null)
                {
                    break;
                }
                if (item.Student.StudentId.CompareTo(studentId) == 0)
                {
                    result[numOfResult++] = item;
                }
            }
            return result;
        }

        // cập nhật số tiết học của một môn học
        public void UpdateSubjectLesson(Subject[] subjects)
        {
            Console.WriteLine("Nhập mã môn học: ");
            var subjectId = int.Parse(Console.ReadLine());
            var subjectIndex = FindSubjectIndexById(subjects, subjectId, subjects.Length);
            if (subjectIndex == -1)
            {
                Console.WriteLine("==> Không tồn tại môn học cần cập nhật. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn cập nhật?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    Console.WriteLine("Số tiết học: ");
                    var lesson = int.Parse(Console.ReadLine());
                    subjects[subjectIndex].NumOfLesson = lesson;
                    Console.WriteLine("==> Cập nhật thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Cập nhật bị hủy. <==");
                }
            }
        }

        // cập nhật thông tin sinh viên khi biết mã sinh viên
        public void UpdateStudentInfo(Student[] students)
        {
            Console.WriteLine("Nhập mã sinh viên: ");
            var studentId = Console.ReadLine().ToUpper(); // viết hoa mã sinh viên
            var filter = new Filter();
            if(!filter.IsStudentIdValid(studentId))
            {
                var message = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(message, studentId);
            }
            var index = FindStudentIndexById(students, studentId, students.Length);
            if (index == -1)
            {
                Console.WriteLine("==> Không tồn tại sinh viên cần cập nhật. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn cập nhật?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    Console.WriteLine("Họ và tên: ");
                    var name = Console.ReadLine();
                    if(!filter.IsNameValid(name))
                    {
                        throw new InvalidNameException("Họ và tên không hợp lệ.", name);
                    }
                    students[index].FullName = new FullName(name);
                    Console.WriteLine("==> Cập nhật thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Cập nhật bị hủy. <==");
                }
            }
        }

        // xóa môn học theo mã cho trước
        public void RemoveSubject(Subject[] subjects, ref int size)
        {
            Console.WriteLine("Nhập mã môn học cần xóa: ");
            var idToRemove = int.Parse(Console.ReadLine());
            int index = FindSubjectIndexById(subjects, idToRemove, size);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy môn học cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    for (int i = index; i < size - 1; i++)
                    {
                        subjects[i] = subjects[i + 1];
                    }
                    size--; // giảm số phần tử trong mảng môn học đi 1 đơn vị
                    Console.WriteLine($"==> Môn học mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa môn học bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của bản đăng ký trong mảng khi biết mã đăng ký
        public int FindSubjectIndexById(Subject[] subjects, int id, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (subjects[i] != null && subjects[i].SubjectId == id)
                {
                    return i;
                }
            }
            return -1; // không tìm thấy
        }

        // xóa sinh viên theo mã cho trước
        public void RemoveStudent(Student[] students, ref int size)
        {
            Console.WriteLine("Nhập mã sinh viên cần xóa: ");
            var idToRemove = Console.ReadLine().ToUpper();
            var filter = new Filter();
            if (!filter.IsStudentIdValid(idToRemove))
            {
                var message = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(message, idToRemove);
            }
            int index = FindStudentIndexById(students, idToRemove, size);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy sinh viên cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    for (int i = index; i < size - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }
                    size--; // giảm số phần tử trong mảng sinh viên đi 1 đơn vị
                    Console.WriteLine($"==> Sinh viên mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa sinh viên bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của sinh viên cần xóa trong mảng
        public int FindStudentIndexById(Student[] students, string id, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (students[i] != null && students[i].StudentId.CompareTo(id) == 0)
                {
                    return i; // tìm thấy
                }
            }
            return -1; // không tìm thấy
        }

        // xóa bản đăng ký theo mã đăng ký
        public void RemoveRegister(Register[] registers, ref int size)
        {
            Console.WriteLine("Nhập mã bản đăng ký cần xóa: ");
            var idToRemove = int.Parse(Console.ReadLine());
            int index = FindRegisterIndexById(registers, idToRemove, size);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy bản đăng ký cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    for (int i = index; i < size - 1; i++)
                    {
                        registers[i] = registers[i + 1];
                    }
                    size--; // giảm số phần tử trong mảng đăng ký đi 1 đơn vị
                    Console.WriteLine($"==> Bản ghi mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa bản đăng ký bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của bản đăng ký trong mảng khi biết mã đăng ký
        public int FindRegisterIndexById(Register[] registers, int id, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (registers[i] != null && registers[i].RegisterId == id)
                {
                    return i;
                }
            }
            return -1; // không tìm thấy
        }
    }
}
