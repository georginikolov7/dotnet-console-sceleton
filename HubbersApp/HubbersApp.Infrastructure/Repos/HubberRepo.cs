using HubbersApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HubbersApp.Infrastructure.Repos;

public class HubberRepo(HubDbContext hubDbContext) : IRepo<Hubber>
{
    public IQueryable<Hubber> GetAll()
    {
        return hubDbContext.Set<Hubber>();
    }

    public IQueryable<Hubber> GetAllReadonly()
    {
        return hubDbContext.Set<Hubber>().AsNoTracking();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await hubDbContext.SaveChangesAsync();
    }
}