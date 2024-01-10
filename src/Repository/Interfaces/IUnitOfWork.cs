using Repository.Models;

namespace Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<User> UserRepository { get; }
    public IRepository<Role> RoleRepository { get; }
}
