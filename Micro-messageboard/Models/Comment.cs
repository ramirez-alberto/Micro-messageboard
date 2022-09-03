using System.ComponentModel.DataAnnotations;

namespace Micro_messageboard.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required]
        [StringLength(140)]
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
