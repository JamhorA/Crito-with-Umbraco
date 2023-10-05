using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class ContactEntity
{
    [Key]
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Message { get; set; } = null!;


}
