using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

TeacherData data = new();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/", GetSomething);
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/teachers/{number}", data.GetTeacher);

app.MapPost("/teachers", data.PostTeacher);

app.Urls.Add("http://*:5086");

app.Run();

static string GetSomething()
{
    return "waz up wit it";
}

class TeacherData
{
  List<Teacher> teachers = new() {
    new Teacher() {Name = "Micke", HitPoints = 100},
    new Teacher() {Name = "Martin", HitPoints = 3},
    new Teacher() {Name = "Lena", HitPoints = 9000}
  };


    public IResult PostTeacher()
    {
        teachers.Add(t);
        System.Console.WriteLine("get posted bitch :0");
        return Results.Ok();
    }

  public IResult GetTeacher(int number)
  {
    if (number < 0 || number >= teachers.Count)
    {
      return Results.NotFound();
    }
    return Results.Ok(teachers[number]);

//return "No teacher"; bitch
 }
 public IResult GetAllTeachers()
    {
     return Results.Ok(teachers);
    }

}
