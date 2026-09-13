using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description {get;set;}
    [Required]
    public decimal Price { get; set; } 
    public string? Images {get;set;}
    [Required]
    public string Category {get;set;}
    [Range(1,5)]
    public int Rating {get;set;}
    public int SellerId {get;set;}
    public Seller Seller {get;set;} // this is navigation proprety to allow access like this -> Product.Seller.Name
    // public List<Review> Reviews {get;set;}

}