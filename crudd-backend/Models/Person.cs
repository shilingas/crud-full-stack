using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public byte[]? Photo { get; set; }
}