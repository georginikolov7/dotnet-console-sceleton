using HubbersApp.Core.DTOs;
using HubbersApp.Core.Services.Interfaces;
using HubbersApp.Infrastructure.Models;
using HubbersApp.Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;

namespace HubbersApp.Core.Services;

public class HubberService(IRepo<Hubber> hubberRepo) : IHubberService
{
    public async Task<IReadOnlyCollection<HubberDto>> GetAllHubbers()
    {
        var result = await hubberRepo.GetAllReadonly()
            .Select(h => new HubberDto()
            {
                Id = h.Id.ToString(),
                Name = h.Name,
            })
            .ToListAsync();
        
        return result;
    }
}