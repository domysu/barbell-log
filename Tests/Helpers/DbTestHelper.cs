using Microsoft.EntityFrameworkCore;
using razorJqueryProject.Data;
using razorJqueryProject.Models;



namespace razorJqueryProject.Tests.Helpers   {


    public class DbTestHelper
    {
        private const string ConnectionString = @"Server=127.0.0.1,1433;Database=ExerciseDB_test;User Id=sa;Password=YourStrong!Pass123;Encrypt=False;TrustServerCertificate=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public DbTestHelper()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.AddRange(
                            new Exercise { Name = "Exercise1", Reps = 20, Sets = 3, Weight = 50.5f, Comment = "First exercise", Created_at = DateTime.Now },
                            new Exercise { Name = "Exercise2", Reps = 20, Sets = 3, Weight = 50.5f, Comment = "First exercise", Created_at = DateTime.Now });
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public ApplicationDbContext CreateContext()
            => new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
    }

