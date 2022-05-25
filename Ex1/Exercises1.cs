/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.25</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace ExercisesLesson83
{
    class Exercises1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            EmployeeUtils utils = new EmployeeUtils();
            BaseEmployee[] employees = new Employee[100];
            int numOfEmployee = 0; // số lượng nhân viên
            utils.CreateFakeData(employees, ref numOfEmployee);

            int choice;
            do
            {
                Console.WriteLine("======================= CÁC CHỨC NĂNG ========================");
                Console.WriteLine("|    1. Thêm mới nhân viên vào danh sách.                    |");
                Console.WriteLine("|    2. Hiển thị danh sách nhân viên ra màn hình.            |");
                Console.WriteLine("|    3. Tính lương các nhân viên trong danh sách.            |");
                Console.WriteLine("|    4. Sắp xếp danh sách nhân viên theo lương thực lĩnh.    |");
                Console.WriteLine("|    5. Sắp xếp danh sách nhân viên theo số ngày đi làm.     |");
                Console.WriteLine("|    6. Tìm và hiển thị thông tin nhân viên theo mã NV.      |");
                Console.WriteLine("|    7. Cập nhật lương cho nhân viên theo mã cho trước.      |");
                Console.WriteLine("|    8. Xóa bỏ nhân viên khi biết mã NV cho trước.           |");
                Console.WriteLine("|    9. Thoát chương trình.                                  |");
                Console.WriteLine("==============================================================");
                Console.WriteLine("==> Xin mời bạn chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var emp = utils.CreateEmployee();
                        if (emp != null)
                        {
                            employees[numOfEmployee++] = emp;
                        }
                        break;
                    case 2:
                        if (numOfEmployee > 0)
                        {
                            utils.ShowEmployee(employees);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 3:
                        if (numOfEmployee > 0)
                        {
                            utils.CalculateSalary(employees);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 4:
                        if (numOfEmployee > 0)
                        {
                            int comparer(BaseEmployee a, BaseEmployee b)
                            {
                                if (a == null && b == null)
                                {
                                    return 0;
                                }
                                else if (a == null && b != null)
                                {
                                    return -1;
                                }
                                else if (a != null && b == null)
                                {
                                    return 1;
                                }
                                return (int)(b.ReceivedSalary - a.ReceivedSalary);
                            };
                            Array.Sort(employees, comparer);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 5:
                        if (numOfEmployee > 0)
                        {
                            int comparer(BaseEmployee a, BaseEmployee b)
                            {
                                if (a == null && b == null)
                                {
                                    return 0;
                                }
                                else if (a == null && b != null)
                                {
                                    return -1;
                                }
                                else if (a != null && b == null)
                                {
                                    return 1;
                                }
                                return (b.WorkingDay > a.WorkingDay) ? 1 : (b.WorkingDay == a.WorkingDay) ? 0 : -1;
                            };
                            Array.Sort(employees, comparer);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 6:
                        if (numOfEmployee > 0)
                        {
                            Console.WriteLine("Nhập mã nhân viên cần tìm: ");
                            var id = Console.ReadLine().ToUpper();
                            var result = utils.FindById(employees, id);
                            if (result != null)
                            {
                                Console.WriteLine("==> Thông tin nhân viên cần tìm: <==");
                                utils.ShowEmployee(new IEmployee[] { result });
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 7:
                        if (numOfEmployee > 0)
                        {
                            Console.WriteLine("Nhập mã nhân viên cần cập nhật lương: ");
                            var id = Console.ReadLine().ToUpper();
                            Console.WriteLine("Nhập mức lương mới: ");
                            var salary = long.Parse(Console.ReadLine());
                            var result = utils.UpdateSalary(employees, id, salary);
                            if (result)
                            {
                                Console.WriteLine("==> Cập nhật thành công! <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Cập nhật thất bại. Nhân viên cần update không tồn tại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 8:
                        if (numOfEmployee > 0)
                        {
                            Console.WriteLine("Nhập mã nhân viên cần xóa: ");
                            var id = Console.ReadLine().ToUpper();
                            var result = utils.RemoveById(employees, id);
                            if (result)
                            {
                                Console.WriteLine("==> Xóa thành công! <==");
                                numOfEmployee--;
                            }
                            else
                            {
                                Console.WriteLine("==> Xóa thất bại. Nhân viên cần xóa không tồn tại. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách nhân viên rỗng <==");
                        }
                        break;
                    case 9:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 9);
        }
    }
}
