using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class ClassService:IClassService
{
   public List<Class> Classes { get; set; }

    private readonly DapperContext context;

    public ClassService()
    {
        context = new DapperContext();
    }


    public bool AddClass(Class class)
    {
        try{
        var insert="insert into Classes (Class_title,level_count,is_active,created_at,updated_at) values(@Class_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,class)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteClass(int id)
    {
        try{
        string deleteCommand=$"Delete from Classes where id=@ClassId";
        var res=context.Connection().Execute(deleteCommand,new {ClassId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayClasss()
    {
        try{
         string readCommand=$"select * from Classes";
         var res=context.Connection().Query<Class>(readCommand).ToList();
         foreach(Class c in Classs)
         {
            System.Console.WriteLine($@"""
            Title = {c.Class_title}
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

    public bool UpdateClass(Class class)
    {
        try{
          string updateComand=$"Update Classes set ClassId=@ClassId Class_title=@Class_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,class);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    


