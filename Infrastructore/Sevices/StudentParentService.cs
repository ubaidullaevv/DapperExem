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
        var insert="insert into StudentParents (studentParentId,studentId,parentId) values(@StudentParentId_,@StudentID,@ParentId)";
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
            StudentId = {c.StudentID}
            ParentId = {c.ParentID}
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
          string updateComand=$"Update StudentParents set StudentParentId=@StudentParentId studentId=@StudentId, parentId=@ParentId";
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

