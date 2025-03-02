namespace BankingCreditSystem.Core.Security.Entities;

public class User : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } // "Customer" veya "BankStaff"
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Role = string.Empty;
        PasswordSalt = Array.Empty<byte>();
        PasswordHash = Array.Empty<byte>();
    }

    public User(
        string firstName,
        string lastName,
        string email,
        string role,
        byte[] passwordSalt,
        byte[] passwordHash,
        bool status = true
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Role = role;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
} 