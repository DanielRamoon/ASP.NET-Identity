using ASP.Data;
using Microsoft.EntityFrameworkCore;
using ASP.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer("server=localhost;database=ASP;user id=sa;password=@Daniel13;TrustServerCertificate=True;"));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDBContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/pattem", (ClaimsPrincipal user) => user.Identity!.Name).RequireAuthorization();
app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
});
app.MapIdentityApi<User>();
app.Run();