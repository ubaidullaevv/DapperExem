using Models;

namespace Interface;


public interface IClassService
{
    public bool AddClass(Class class);
    public bool UpdateClass(Class class);
    public bool DeleteClass(int id);
    public void DisplayClasss();
}