using System.Text.RegularExpressions;

namespace L83Exercises3
{
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
