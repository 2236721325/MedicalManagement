using Base.Shared.Domains;

namespace UserManagement.Domain.Models
{
    public class Permission:BaseEntity<long>
    {
        public string Name { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public Permission(string name ,long userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
