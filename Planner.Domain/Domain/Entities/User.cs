namespace Planner.Domain.Domain.Entities;

public class User
{
    protected User(string name, string email, string password, bool admin)
    {
        Id = new Guid();
        Name = name;
        Email = email;
        Password = password;
        Admin = admin;
        Active = true;
        CreateDate = DateTime.UtcNow;
    }

    public User()
    {
        
    }
    
    
    public static User New(string name, string email, string password, bool admin)
    {
        return new User(name, email, password, admin);
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool Admin { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public bool Active { get; private set; }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    public void UpdateAdmin(bool admin)
    {
        Admin = admin;
    }

    public void UpdateActive(bool active)
    {
        Active = active;
    }

    public void UpdateNameEmail(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
