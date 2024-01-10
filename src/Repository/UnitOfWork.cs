using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public Repository<User> _userRepository;
    public Repository<Role> _roleRepository { get; }
    
    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public IRepository<User> UserRepository => _userRepository;
    public IRepository<Role> RoleRepository => _roleRepository;
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
