using eLibrary.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Data;

public class eLibraryDbContext : IdentityDbContext<User>
{
    public eLibraryDbContext(DbContextOptions<eLibraryDbContext> options) : base(options) { }
}
