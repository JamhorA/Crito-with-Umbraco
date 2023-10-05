using Crito.Models;
using Microsoft.EntityFrameworkCore;

namespace Crito.Contexts;

public class DataContextName : DbContext
{
    public DataContextName()
    {

    }

    public DataContextName(DbContextOptions<DataContextName> options) : base(options)
    {
    }

    public DbSet<ContactEntity> Contacts { get; set; }
}
