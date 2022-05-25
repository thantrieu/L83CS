/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.25</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace L83Exercises2
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var studentUtils = new StudentManagermentUtils();
            Student[] students = new Student[100];
            Subject[] subjects = new Subject[100];
            Register[] registers = new Register[100];
            int numOfStudent = 0; // số lượng sinh viên
            int numOfSubject = 0; // số lượng môn học
            int numOfRegister = 0; // số lượng bản đăng ký
            studentUtils.CreateFakeStudents(students, ref numOfStudent);
            studentUtils.CreateFakeSubjects(subjects, ref numOfSubject);
            studentUtils.CreateFakeRegisters(registers, ref numOfRegister, students, subjects);
            int choice;

            do
            {
                Console.WriteLine("=========================> CÁC CHỨC NĂNG <========================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách sinh viên.             *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách môn học.                 *");
                Console.WriteLine("*    03. Thêm mới bản đăng ký môn học vào danh sách đăng ký.     *");
                Console.WriteLine("*    04. Hiển thị danh sách sinh viên ra màn hình.               *");
                Console.WriteLine("*    05. Hiển thị danh sách môn học ra màn hình.                 *");
                Console.WriteLine("*    06. Hiển thị danh sách đăng ký ra màn hình.                 *");
                Console.WriteLine("*    07. Sắp xếp danh sách sinh viên theo tên a-z.               *");
                Console.WriteLine("*    08. Sắp xếp danh sách môn học theo số tín chỉ giảm dần.     *");
                Console.WriteLine("*    09. Sắp xếp danh sách đăng ký theo thời gian đăng ký.       *");
                Console.WriteLine("*    10. Sắp xếp danh sách đăng ký theo mã sinh viên.            *");
                Console.WriteLine("*    11. Sắp xếp danh sách đăng ký theo mã môn học.              *");
                Console.WriteLine("*    12. Tìm danh sách đăng ký theo mã môn học.                  *");
                Console.WriteLine("*    13. Tìm danh sách đăng ký theo mã sinh viên.                *");
                Console.WriteLine("*    14. Sửa tên sinh viên theo mã sinh viên cho trước.          *");
                Console.WriteLine("*    15. Sửa số tiết học theo mã môn học cho trước.              *");
                Console.WriteLine("*    16. Xóa môn học khỏi danh sách môn học.                     *");
                Console.WriteLine("*    17. Xóa sinh viên khỏi danh sách sinh viên.                 *");
                Console.WriteLine("*    18. Xóa bản đăng ký theo mã đăng ký.                        *");
                Console.WriteLine("*    19. Thoát chương trình.                                     *");
                Console.WriteLine("==================================================================");
                Console.WriteLine("==> Xin mời bạn chọn chức năng:  ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            var newStudent = studentUtils.CreateStudent(students);
                            if (newStudent != null)
                            {
                                students[numOfStudent++] = newStudent;
                                Console.WriteLine("==> Tạo sinh viên thành công!");
                            }
                            else
                            {
                                Console.WriteLine("==> Tạo mới sinh viên thất bại.");
                            }
                        } 
                        catch(InvalidStudentIdException e) { Console.WriteLine(e); }
                        catch (InvalidNameException e) { Console.WriteLine(e.Message); }
                        catch (InvalidPhoneNumberException e) { Console.WriteLine(e.Message); }
                        catch (InvalidEmailException e) { Console.WriteLine(e.Message); }
                        catch (InvalidBirthDateException e) { Console.WriteLine(e.Message); }
                        break;
                    case 2:
                        var newSubject = studentUtils.CreateSubject();
                        if (newSubject != null)
                        {
                            subjects[numOfSubject++] = newSubject;
                        }
                        break;
                    case 3:
                        if (numOfStudent > 0 && numOfSubject > 0)
                        {
                            var newRegister = studentUtils.CreateRegister(students, subjects);
                            if (newRegister != null && newRegister.Subject != null && newRegister.Student != null)
                            {
                                if (!studentUtils.Contains(registers, newRegister))
                                {
                                    registers[numOfRegister++] = newRegister;
                                    Console.WriteLine($"==> Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đăng ký thành công môn học \"{newRegister.Subject.SubjectId}\". <==");
                                }
                                else
                                {
                                    Console.WriteLine($"==> Lỗi. Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đã đăng ký môn học \"{newRegister.Subject.SubjectId}\" trước đó. <==");
                                }
                            }
                            else if (newRegister.Subject == null)
                            {
                                Console.WriteLine("==> Môn học cần đăng ký không tồn tại. <==");
                            }
                            else if (newRegister.Student == null)
                            {
                                Console.WriteLine("==> Sinh viên cần đăng ký không tồn tại. <==");
                            }
                        }
                        else
                        {
                            if (numOfStudent == 0)
                            {
                                Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                            }
                            if (numOfSubject == 0)
                            {
                                Console.WriteLine("==> Danh sách môn học rỗng <==");
                            }
                        }
                        break;
                    case 4:
                        if (numOfStudent > 0)
                        {
                            studentUtils.ShowStudents(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 5:
                        if (numOfSubject > 0)
                        {
                            studentUtils.ShowSubjects(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 6:
                        if (numOfRegister > 0)
                        {
                            studentUtils.ShowRegisters(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 7:
                        if (numOfStudent > 0)
                        {
                            studentUtils.SortStudentByName(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 8:
                        if (numOfSubject > 0)
                        {
                            studentUtils.SortSubjectByCredit(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 9:
                        if (numOfRegister > 0)
                        {
                            studentUtils.SortRegistersByRegTime(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 10:
                        if (numOfRegister > 0)
                        {
                            studentUtils.SortRegistersByStudentId(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 11:
                        if (numOfRegister > 0)
                        {
                            studentUtils.SortRegistersBySubjectId(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 12:
                        if (numOfRegister > 0)
                        {
                            var result = studentUtils.FindRegisterBySubjectId(registers);
                            if (result[0] == null)
                            {
                                Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Kết quả tìm kiếm theo mã môn học: <==");
                                studentUtils.ShowRegisters(result);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 13:
                        if (numOfRegister > 0)
                        {
                            try
                            {
                                var result = studentUtils.FindRegisterByStudentId(registers);
                                if (result[0] == null)
                                {
                                    Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                                }
                                else
                                {
                                    Console.WriteLine("==> Kết quả tìm kiếm theo mã sinh viên: <==");
                                    studentUtils.ShowRegisters(result);
                                }
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 14:
                        if (numOfStudent > 0)
                        {
                            try
                            {
                                studentUtils.UpdateStudentInfo(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidNameException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 15:
                        if (numOfSubject > 0)
                        {
                            studentUtils.UpdateSubjectLesson(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 16:
                        if (numOfSubject > 0)
                        {
                            studentUtils.RemoveSubject(subjects, ref numOfSubject);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 17:
                        if (numOfStudent > 0)
                        {
                            try
                            {
                                studentUtils.RemoveStudent(students, ref numOfStudent);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 18:
                        if (numOfRegister > 0)
                        {
                            studentUtils.RemoveRegister(registers, ref numOfRegister);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 19:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 19);
        }
    }
}
