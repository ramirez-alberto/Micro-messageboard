using System.ComponentModel.DataAnnotations;

namespace Micro_messageboard.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8)]
        public string Password { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
