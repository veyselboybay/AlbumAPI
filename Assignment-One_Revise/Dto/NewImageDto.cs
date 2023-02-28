using System.ComponentModel.DataAnnotations;

namespace Assignment_One_Revise.Dto
{
    public class NewImageDto
    {
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
