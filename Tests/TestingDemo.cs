using Xunit;
using razorJqueryProject.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using razorJqueryProject.Models;
using razorJqueryProject.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace razorJqueryProject.Tests
{
    public class TestingDemo : IClassFixture<DbTestHelper>
    {

        private readonly ApplicationDbContext _context;
        private readonly IDbContextTransaction _transaction;
        public TestingDemo(DbTestHelper fixture)
        {
            _context = fixture.CreateContext();
            _transaction = _context.Database.BeginTransaction();

        }

        [Fact]
        public void Can_Create_Exercise()
        {
            try
            {
                var exercise = new Exercise
                {
                    Name = "test",
                    Reps = 10,
                    Sets = 3,
                    Weight = 75,
                    Comment = "This is a test exercise",
                    Created_at = DateTime.Now
                };

                _context.Exercise.Add(exercise);
                _context.SaveChanges();

                Assert.NotEqual(0, exercise.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed with exception: {ex.Message}");
            }
            finally
            {
                _transaction.Rollback();
            }
        }
        
    }
}