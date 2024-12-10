using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class StudentParentService:IStudentParentService
{
   public List<StudentParent> StudentParents { get; set; }

    private readonly DapperContext context;

    public StudentParentService()
    {
        context = new DapperContext();
    }


    public bool AddStudentParent(StudentParent studentParent)
    {
        try{
        var insert="insert into StudentParents (StudentParent_title,level_count,is_active,created_at,updated_at) values(@StudentParent_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,studentParent)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteStudentParent(int id)
    {
        try{
        string deleteCommand=$"Delete from StudentParents where id=@StudentParentId";
        var res=context.Connection().Execute(deleteCommand,new {StudentParentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayStudentParents()
    {
        try{
         string readCommand=$"select * from StudentParents";
         var res=context.Connection().Query<StudentParent>(readCommand).ToList();
         foreach(StudentParent c in StudentParents)
         {
            System.Console.WriteLine($@"""
            Title = {c.StudentParent_title}
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

    public bool UpdateStudentParent(StudentParent studentParent)
    {
        try{
          string updateComand=$"Update StudentParents set StudentParentId=@StudentParentId StudentParent_title=@StudentParent_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,studentParent);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

