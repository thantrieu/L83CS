namespace ExercisesLesson83
{
    interface IFilter
    {
        bool IsNameValid(string name);
        bool IsEmailValid(string email);
        bool IsPhoneValid(string phone);
        bool IsEmpIdValid(string empId);
    }
}
