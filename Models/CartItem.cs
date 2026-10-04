using System.ComponentModel.DataAnnotations;

public class CartItem
{
    [Key]
    public int Id {set;get;}
    [Required]
    public int CustomerId {set;get;}

    public User? Customer {set;get;}
    public int? Amount {set;get;}
    [Required]
    public int ProductId {get;set;}
    public Product? Product {get;set;}
}
