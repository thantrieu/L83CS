﻿namespace L83Exercises2
{
    interface IFilter
    {
        // phương thức kiểm tra mã sinh viên có hợp lệ không
        bool IsStudentIdValid(string studentId);
        // phương thức kiểm tra tên có hợp lệ không
        bool IsNameValid(string name);
        // phương thức kiểm tra email có hợp lệ không
        bool IsEmailValid(string email);
        // phương thức kiểm tra số điện thoại có hợp lệ không
        bool IsPhoneValid(string phone);
        // phương thức kiểm tra ngày sinh có hợp lệ không
        bool IsBirthDateValid(string birthDate);
    }
}
