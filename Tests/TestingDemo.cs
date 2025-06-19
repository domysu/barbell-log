using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using razorJqueryProject.Controllers;
using razorJqueryProject.Models;
using razorJqueryProject.Tests.Helpers;
using Xunit;

namespace razorJqueryProject.Tests
{
    public class ExerciseTests : DbTestBase
    {
        [Fact]
        public async Task Can_Create_Exercise_With_User()
        {
            // Arrange
            var user = new User
            {
                Username = "testuser",
                Password = "password123"
            };

            Context.Users.Add(user);
            await Context.SaveChangesAsync();

            var exercise = new Exercise
            {
                Name = "Deadlift",
                Reps = 5,
                Sets = 4,
                Weight = 150,
                Comment = "Heavy set",
                Created_at = DateTime.Now,
                UserId = user.Id
            };

            // Act
            Context.Exercise.Add(exercise);
            await Context.SaveChangesAsync();

            // Assert
            Assert.NotEqual(0, exercise.Id);
            Assert.Equal(user.Id, exercise.UserId);
        }

        [Fact]
        public async Task Checks_If_User_Already_Exists()
        {
            // Arrange
            var user = new User
            {
                Username = "User",
                Password = "Password"

            };
            var registerViewModal = new Register
            {
                Username = "User",
                Password = "Password",
                ConfirmPassword = "Password",
            };
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            var controller = new AuthController(Context);

            // Act
            var result = await controller.Register(registerViewModal);

            //Assert
             var view = Assert.IsType<ViewResult>(result);
             Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey("Username"));

        }
    }
}
