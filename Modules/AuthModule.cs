using MSC_55.Data;
using MSC_55.Models;

namespace MSC_55.Modules
{
    public static class AuthModule
    {
        public static WebApplication MapAuthApi(this WebApplication app)
        {
            var authApi = app.MapGroup("api/auth");

            authApi.MapPost("/login", (User request) =>
            {
            var userExisted = AuthCollection.Users.FirstOrDefault(user => user.UserName == request.UserName);
                                                                            //& user.Password == request.Password);

                if (userExisted == null)
                {
                    return Results.StatusCode(404);
                }

                var token = JwtService.GenerateToken(userExisted);

                return Results.Ok(token);
            });

            return app;
        }
    }
}
