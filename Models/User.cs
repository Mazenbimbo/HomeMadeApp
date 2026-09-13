using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public enum roles
    {
        Admin,
        Saler,
        Delivery,
        Customer
    }

    [Key]
    public int ID { get; set; }
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    public roles Role { get; set; } = roles.Customer;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string? Phone {get;set;}
    [Required]
    public string Password { get; set; } = string.Empty;
    public string? Image {set;get;}
    [Required]
    public string City{set;get;} = string.Empty;
    [Range(1,5)]
    public int? Rating{set;get;}
}

