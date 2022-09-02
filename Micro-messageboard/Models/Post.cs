using System.ComponentModel.DataAnnotations;

namespace Micro_messageboard.Models
{
    public class Post
    {
        public Post()
        {
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        public int PostId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
