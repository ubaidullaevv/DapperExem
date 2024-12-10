namespace Models;



public class Teacher 
{
public int TeacherId { get; set; }
public string? Teacher_code { get; set; }
public string? Fullname { get; set; }
public string? Gender { get; set; }
public DateTime Dob { get; set; }
public string? Email { get; set; }
public string? Phone { get; set; }
public bool Is_active { get; set; }
public int Working_days { get; set; }
public DateTime Created_at { get; set; }
public DateTime Updated_at { get; set; }
}