namespace StudentPlatform.API.Models;

public class Teacher(string name, int id)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public ICollection<Course> Courses {get; set;} = new List<Course>();
}