using Base.Shared.Domains;

namespace UserManagement.Domain.Models
{
    public class User : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string PasswordHash { get; set; }
        public User(string name, string account, string passwordHash)
        {
            Name = name;
            Account = account;
            PasswordHash = passwordHash;
        }
    }
}
