using Models;

namespace Interface;


public interface ITeacherService
{
    public bool AddTeacher(Teacher teacher);
    public bool UpdateTeacher(Teacher teacher);
    public bool DeleteTeacher(int id);
    public void DisplayTeachers();
}