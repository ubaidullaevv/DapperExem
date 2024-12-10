using Models;

namespace Interface;


public interface ISchoolService
{
    public bool AddSchool(School school);
    public bool UpdateSchool(School school);
    public bool DeleteSchool(int id);
    public void DisplaySchools();
}