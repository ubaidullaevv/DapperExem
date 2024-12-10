using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class SchoolService:ISchoolService
{
   public List<School> Schools { get; set; }

    private readonly DapperContext context;

    public SchoolService()
    {
        context = new DapperContext();
    }


    public bool AddSchool(School school)
    {
        try{
        var insert="insert into schools (school_title,level_count,is_active,created_at,updated_at) values(@School_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,school)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteSchool(int id)
    {
        try{
        string deleteCommand=$"Delete from Schools where id=@SchoolId";
        var res=context.Connection().Execute(deleteCommand,new {SchoolId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplaySchools()
    {
        try{
         string readCommand=$"select * from Schools";
         var res=context.Connection().Query<School>(readCommand).ToList();
         foreach(School c in Schools)
         {
            System.Console.WriteLine($@"""
            Title = {c.School_title}
            Level_count = {c.Level_count}
            Is_active = {c.Is_active}
            Created_at = {c.Created_at}
            Updated_at = {c.Updated_at}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateSchool(School school)
    {
        try{
          string updateComand=$"Update Schools set schoolId=@SchoolId school_title=@School_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,school);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    

