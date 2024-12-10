using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class SubjectService:ISubjectService
{
   public List<Subject> Subjects { get; set; }

    private readonly DapperContext context;

    public SubjectService()
    {
        context = new DapperContext();
    }


    public bool AddSubject(Subject subject)
    {
        try{
        var insert="insert into Subjects (title,schoolId,stage,term,carry_mark,created_at,updated_at) values(@Title,@SchoolId,@Stage,@Term,@Carry_mark,@Created_at@Updated_at)";
        var res=context.Connection().Execute(insert,subject)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteSubject(int id)
    {
        try{
        string deleteCommand=$"Delete from Subjects where id=@SubjectId";
        var res=context.Connection().Execute(deleteCommand,new {SubjectId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplaySubjects()
    {
        try{
         string readCommand=$"select * from Subjects";
         var res=context.Connection().Query<Subject>(readCommand).ToList();
         foreach(Subject c in Subjects)
         {
            System.Console.WriteLine($@"""
            Title = {c.Subject_title}
            SchoolId = {c.SchoolId}
            Stage = {c.Is_active}
            Term = {c.Is_active}
            Carry_mark = {c.Carry_mark}
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

    public bool UpdateSubject(Subject subject)
    {
        try{
          string updateComand=$"Update Subjects set subjectId=@SubjectId title=@Title, schoolId=@SchoolId,stage=@Stage,term=@Term,carry_mark=@Carry_mark, created_at=@Created_at, updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,subject);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    


