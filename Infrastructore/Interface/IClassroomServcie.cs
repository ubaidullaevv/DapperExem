using Models;

namespace Interface;


public interface IClassroomService
{
    public bool AddClassroom(Classroom classroom);
    public bool UpdateClassroom(Classroom classroom);
    public bool DeleteClassroom(int id);
    public void DisplayClassrooms();
}