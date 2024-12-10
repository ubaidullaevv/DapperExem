namespace Models;



public class Classroom 
{
    public int ClassroomId { get; set; }
    public int Capacity { get; set; }
    public int Room_type { get; set; }
    public string? Description { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}