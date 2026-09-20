using System.ComponentModel.DataAnnotations;

public class Seller
{
    [Key]
    public int Id {get;set;}
    [Required]
    public string Name {get;set;} = string.Empty;
    public string? Image {get;set;}
    [Phone]
    public string? Phone {get;set;} 
    [Required]
    [EmailAddress]
    public string Email {get;set;} = string.Empty;
    [Required]
    public string Password {get;set;} = string.Empty;
    [Required]
    public string City {get;set;} = string.Empty;
    [Range(1,5)]
    public string? Rating {get;set;}
    public int? NumberOfProductsSold {get;set;}
    public List<Product> Products {get;set;} = new();
}