using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosFinance.Domain.Entities;

public class User
{ 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public PersonType Type { get; set; }
}

public enum PersonType
{
    PF,
    PJ
}