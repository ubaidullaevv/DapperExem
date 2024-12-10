using Models;

namespace Interface;


public interface IParentService
{
    public bool AddParent(Parent parent);
    public bool UpdateParent(Parent parent);
    public bool DeleteParent(int id);
    public void DisplayParents();
}