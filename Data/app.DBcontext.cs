using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.Models;
namespace ASP.Data;


public class AppDBContext(DbContextOptions options) 
: IdentityDbContext<User>(options);
