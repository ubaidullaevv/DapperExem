namespace Models;




public class Class 
{
    public int ClassId { get; set; }
    public string? Name { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public int ClassroomId { get; set; }
    public string? Section { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}