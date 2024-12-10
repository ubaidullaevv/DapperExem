namespace Models;



public class Student
{
    public int StudentId { get; set; }
    public string? Student_code { get; set; }
    public string? Fullname { get; set; }
    public string? Gender { get; set; }
    public DateTime Dob { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int SchoolId { get; set; }
    public int Stage { get; set; }
    public string Section { get; set; }
    public bool Is_active { get; set; }
    public DateTime Join_date { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}