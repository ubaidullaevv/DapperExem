namespace Models;




public class StudentParent
{
    public int StudentParentsId { get; set; }
    public int StudentId { get; set; }
    public int ParentId { get; set; }
    public int Relationship { get; set; }
}