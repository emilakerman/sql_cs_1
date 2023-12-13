namespace StudentPlatform.API.Models;

public class Course(string name)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public Teacher? Teacher { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
