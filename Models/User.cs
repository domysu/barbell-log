using System.ComponentModel.DataAnnotations;
namespace razorJqueryProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}