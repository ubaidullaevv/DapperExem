namespace Models;



public class Parent
{
    public int ParentId { get; set; }
    public string? Parent_code { get; set; }
    public string? Fullname { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}