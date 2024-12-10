using Models;

namespace Interface;


public interface ISubjectService
{
    public bool AddSubject(Subject subject);
    public bool UpdateSubject(Subject subject);
    public bool DeleteSubject(int id);
    public void DisplaySubjects();
}