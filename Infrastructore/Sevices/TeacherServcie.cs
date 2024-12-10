using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class TeacherService:ITeacherService
{
   public List<Teacher> Teachers { get; set; }

    private readonly DapperContext context;

    public TeacherService()
    {
        context = new DapperContext();
    }


    public bool AddTeacher(Teacher teacher)
    {
        try{
        var insert="insert into Teachers (teacher_code,fullname,gender,dob,email,Phone,is_active,working_days,created_at,updated_at) values(@Teacher_code,@Fullname,@Gender,@Dob,@Email,@Phone,@Is_active,@Working_days,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,teacher)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteTeacher(int id)
    {
        try{
        string deleteCommand=$"Delete from Teachers where id=@TeacherId";
        var res=context.Connection().Execute(deleteCommand,new {TeacherId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayTeachers()
    {
        try{
         string readCommand=$"select * from Teachers";
         var res=context.Connection().Query<Teacher>(readCommand).ToList();
         foreach(Teacher c in Teachers)
         {
            System.Console.WriteLine($@"""
            Teacher_code = {c.Teacher_code}
            Fullname = {c.Fullname}
            Gender = {c.Gender}
            Dob = {c.Dob}
            Email = {c.Email}
            Phone = {c.Phone}
            Is_active = {c.Is_active}
            Working_days = {c.Working_days}
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

    public bool UpdateTeacher(Teacher teacher)
    {
        try{
          string updateComand=$"Update Teachers set еeacherId=@TeacherId Teacher_code=@Teacher_code, Fullname=@Fullname,Gender=@Gender,dob=@Dob,email=@Email,phone=@Phone,is_active=@Is_active,working_days=@Working_days Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,teacher);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    


