using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_One_Revise.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
