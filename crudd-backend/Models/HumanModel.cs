using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudd_backend.Models
{
    public class HumanModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("integer(50)")]
        public string Name { get; set; } = null!;
        [Required]
        [Column("integer(50)")]
        public string Surname { get; set; } = null!;
        [Required]
        [Column("integer(50)")]
        public int Age { get; set; }

    }
}
