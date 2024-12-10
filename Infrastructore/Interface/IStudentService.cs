using Models;

namespace Interface;


public interface IStudentService
{
    public bool AddStudent(Student student);
    public bool UpdateStudent(Student student);
    public bool DeleteStudent(int id);
    public void DisplayStudents();
}