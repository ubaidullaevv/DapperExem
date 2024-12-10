using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class ClassroomService:IClassroomService
{
   public List<Classroom> Classrooms { get; set; }

    private readonly DapperContext context;

    public ClassroomService()
    {
        context = new DapperContext();
    }


    public bool AddClassroom(Classroom classroom)
    {
        try{
        var insert="insert into Classrooms (Classroom_title,level_count,is_active,created_at,updated_at) values(@Classroom_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,classroom)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteClassroom(int id)
    {
        try{
        string deleteCommand=$"Delete from Classrooms where id=@ClassroomId";
        var res=context.Connection().Execute(deleteCommand,new {ClassroomId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayClassrooms()
    {
        try{
         string readCommand=$"select * from Classrooms";
         var res=context.Connection().Query<Classroom>(readCommand).ToList();
         foreach(Classroom c in Classrooms)
         {
            System.Console.WriteLine($@"""
            Title = {c.Classroom_title}
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

    public bool UpdateClassroom(Classroom classroom)
    {
        try{
          string updateComand=$"Update Classrooms set ClassroomId=@ClassroomId Classroom_title=@Classroom_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,classroom);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    


