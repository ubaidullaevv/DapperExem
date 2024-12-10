using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class ParentService:IParentService
{
   public List<Parent> Parents { get; set; }

    private readonly DapperContext context;

    public ParentService()
    {
        context = new DapperContext();
    }


    public bool AddParent(Parent parent)
    {
        try{
        var insert="insert into Parents (Parent_title,level_count,is_active,created_at,updated_at) values(@Parent_title,@Level_count,@Is_active,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,parent)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteParent(int id)
    {
        try{
        string deleteCommand=$"Delete from Parents where id=@ParentId";
        var res=context.Connection().Execute(deleteCommand,new {ParentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayParents()
    {
        try{
         string readCommand=$"select * from Parents";
         var res=context.Connection().Query<Parent>(readCommand).ToList();
         foreach(Parent c in Parents)
         {
            System.Console.WriteLine($@"""
            Title = {c.Parent_title}
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

    public bool UpdateParent(Parent parent)
    {
        try{
          string updateComand=$"Update Parents set ParentId=@ParentId Parent_title=@Parent_title, level_count=@Level_count,is_active=@Is_active, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,parent);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    

