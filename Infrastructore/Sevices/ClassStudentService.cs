using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class ClassStudentService:IClassStudentService
{
   public List<ClassStudent> ClassStudents { get; set; }

    private readonly DapperContext context;

    public ClassStudentService()
    {
        context = new DapperContext();
    }


    public bool AddClassStudent(ClassStudent classStudent)
    {
        try{
        var insert="insert into ClassStudents (ClassStudent_title,level_count,is_active,created_at,updated_at) values(@ClassStudent_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,classStudent)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteClassStudent(int id)
    {
        try{
        string deleteCommand=$"Delete from ClassStudents where id=@ClassStudentId";
        var res=context.Connection().Execute(deleteCommand,new {ClassStudentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayClassStudents()
    {
        try{
         string readCommand=$"select * from ClassStudents";
         var res=context.Connection().Query<ClassStudent>(readCommand).ToList();
         foreach(ClassStudent c in ClassStudents)
         {
            System.Console.WriteLine($@"""
            Title = {c.ClassStudent_title}
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

    public bool UpdateClassStudent(ClassStudent classStudent)
    {
        try{
          string updateComand=$"Update ClassStudents set ClassStudentId=@ClassStudentId ClassStudent_title=@ClassStudent_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,classStudent);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    


