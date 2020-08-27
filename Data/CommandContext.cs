using Commands.Models;
using Microsoft.EntityFrameworkCore;

namespace Commands.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opt) : base(opt)
        {

        }

        //DB SETS
        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }

    }
}