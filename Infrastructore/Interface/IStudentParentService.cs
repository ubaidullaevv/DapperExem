using Models;

namespace Interface;


public interface IStudentparentService
{
    public bool AddStudentparent(Studentparent studentparent);
    public bool UpdateStudentparent(Studentparent studentparent);
    public bool DeleteStudentparent(int id);
    public void DisplayStudentparents();
}