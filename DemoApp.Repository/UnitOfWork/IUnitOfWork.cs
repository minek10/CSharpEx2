using DemoApp.Repository.Interfaces;

namespace DemoApp.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        
    }
}