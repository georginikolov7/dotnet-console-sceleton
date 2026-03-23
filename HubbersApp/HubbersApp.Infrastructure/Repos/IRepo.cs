namespace HubbersApp.Infrastructure.Repos;

public interface IRepo<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAllReadonly();
    Task<int> SaveChangesAsync();
}