using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]

    public string? FirstName { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string? LastName { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string? ImageName { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    [NotMapped]
    public string? ImageSrc { get; set; }
}