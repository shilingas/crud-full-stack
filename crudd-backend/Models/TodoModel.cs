using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudd_backend.Models
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string? Date { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Text { get; set; }

    }
}
