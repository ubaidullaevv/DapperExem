using Models;

namespace Interface;


public interface IClassStudentService
{
    public bool AddClassStudent(ClassStudent classStudent);
    public bool UpdateClassStudent(ClassStudent classStudent);
    public bool DeleteClassStudent(int id);
    public void DisplayClassStudents();
}