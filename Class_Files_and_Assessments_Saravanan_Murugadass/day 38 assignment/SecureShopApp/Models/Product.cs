using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    [Range(0.1, 10000)]
    public decimal Price { get; set; }
}
