using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MSC_55.Data;
using MSC_55.Models;

namespace MSC_55.Modules
{
    public static class StudentModule
    {
        public static WebApplication MapStudentApi(this WebApplication app)
        {
            var studentApi = app.MapGroup("/api/student").RequireAuthorization(policy => policy.RequireRole("admin"));

            studentApi.MapGet("/list", () =>
            {
                return StudentCollection.Students;
            });

            studentApi.MapGet("/get/{id}", (int id) =>
            {
                var student = StudentCollection.Students.FirstOrDefault(x => x.Id == id);

                return student;
            });

            studentApi.MapPost("/add", (Student student) =>
            {
                StudentCollection.AddNewStudent(student);

                return Results.Ok(student);
            });

            studentApi.MapDelete("/delete/{id}", (int id) =>
            {
                var student = StudentCollection.Students.FirstOrDefault(x => x.Id == id);

                if (student == null)
                {
                    return Results.StatusCode(500);
                }

                StudentCollection.Students.Remove(student);
                return Results.Ok();
            });

            return app;
        }
    }
}
