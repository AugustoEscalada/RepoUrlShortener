using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAcortadorURL.Entities
{
    public class ShortenedURL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? LongURL { get; set; }
        [Required]
        public string? ShortURL { get; set; }
        [Required]
        public int views { get; set; }


    }
}
