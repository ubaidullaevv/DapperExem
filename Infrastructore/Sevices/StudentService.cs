using Models;
using Interface;
using Infrastructure.DataContext;
using Npgsql;
using Dapper;
namespace Services;


public class StudentService:IStudentService
{
   public List<Student> Students { get; set; }

    private readonly DapperContext context;

    public StudentService()
    {
        context = new DapperContext();
    }


    public bool AddStudent(Student student)
    {
        try{
        var insert="insert into Students (student_code,fullname,gender,dob,email,phone,schoolId,is_active,join_date,created_at,updated_at) values(@Student_code,@Fullname,@Gender,@Dob,@Email,@Phone,@SchoolId,@Is_active,@Join_date,@Created_at,@Updated_at)";
        var res=context.Connection().Execute(insert,student)
        return res>0;
        }
               catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

 
    

    public bool DeleteStudent(int id)
    {
        try{
        string deleteCommand=$"Delete from Students where id=@StudentId";
        var res=context.Connection().Execute(deleteCommand,new {StudentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayStudents()
    {
        try{
         string readCommand=$"select * from Students";
         var res=context.Connection().Query<Student>(readCommand).ToList();
         foreach(Student c in Students)
         {
            System.Console.WriteLine($@"""
            Student_code = {c.Student_code}
            Fullname = {c.Fullname}
            Gender ={c.Gender}
            Dob ={c.Dob}
            Email ={c.Email}
            Phone ={c.Phone}
            SchoolId ={c.SchoolId}
            Is_active = {c.Is_active}
            Join Date = {c.Join_date}
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

    public bool UpdateStudent(Student student)
    {
        try{
          string updateComand=$"Update Students set studentId=@StudentId , student_code=@Student_code, fullname=@Fullname,dob=@Dob,email=@Email,phone=@Phone,schoolId=@SchoolId,is_active=@Is_active,join_date=@Join_date, Created_at=@Created_at, Updated_at=@Updated_at";
          var res=context.Connection().Execute(updateComand,student);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    

