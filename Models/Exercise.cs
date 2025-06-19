
using System.ComponentModel.DataAnnotations;

namespace razorJqueryProject.Models

{

    public class Exercise
    {


        private float _weight;
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public float Weight
        {
            get => _weight;
            set => _weight = (float)Math.Round(value, 2);
        }
        [Required]
        public int Reps { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
        public DateTime Created_at { get; set; }

        public User User { get; set; } = default!; // Navigation property to User

    }

   

}