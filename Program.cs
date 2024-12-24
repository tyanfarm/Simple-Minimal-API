using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MSC_55;
using MSC_55.Data;
using MSC_55.Modules;
using SBT.Shared.DAO;

var builder = WebApplication.CreateBuilder(args);

// config swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new() { Title = "Testing Minimal API", Version = "v1" });
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            new List<string>()
        }
    });

    // api by module
    options.TagActionsBy(api =>
    {
        var tag = api.RelativePath.Split('/')[1]; 
        return new[] { tag };
    });
});

builder.Services.AddDbConnection();

// config jwt authenticate 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = JwtService.TokenValidationParameters;
                });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

SnapbotoSchema.Instance.Register();
var app = builder.Build();

StudentCollection.Init();

// use swagger
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint(
    "/swagger/v1/swagger.json",
    "v1"
));

app.UseAuthentication();
app.UseAuthorization();

app.MapStudentApi();
app.MapAuthApi();
app.MapTickerApi();

app.Run();
