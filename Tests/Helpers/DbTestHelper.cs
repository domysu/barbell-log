using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using razorJqueryProject.Data;
using razorJqueryProject.Models;



namespace razorJqueryProject.Tests.Helpers   {


   public abstract class DbTestBase : IAsyncLifetime
{
    protected ApplicationDbContext Context { get; private set; }
    private IDbContextTransaction _transaction;

    public async Task InitializeAsync()
    {
        Context = new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=127.0.0.1,1433;Database=ExerciseDB_test;User Id=sa;Password=YourStrong!Pass123;Encrypt=False;TrustServerCertificate=True;")
                .Options);

        _transaction = await Context.Database.BeginTransactionAsync();
    }

    public async Task DisposeAsync()
    {
        await _transaction.RollbackAsync(); // nukes all changes after each test
        await Context.DisposeAsync();
    }
}

    }

