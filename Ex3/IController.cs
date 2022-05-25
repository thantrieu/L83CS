namespace L83Exercises3
{
    // interface mô tả các hành động của hệ thống
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
}
