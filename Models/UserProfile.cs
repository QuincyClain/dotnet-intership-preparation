using Tasks;

namespace OopPractice;

public class UserProfile
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    private string _passwordHash;

    public UserProfile(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username can not be empty");
        }
        
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Email must contain an @ symbol!");
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            throw new ArgumentException("Password must contain atleast 6 characters");
        }

        Username = username;
        Email = email;
        _passwordHash = HashPassword(password);
    }

    private string HashPassword(string password)
    {
        return $"HASHED_{password}";
    }

    public void ChangeEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
        {
            throw new ArgumentException("Email must contain an @ symbol!");
        }

        Email = newEmail;
    }

    public bool CheckPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        return HashPassword(password) == _passwordHash;
    }
}