using HubbersApp.Core.DTOs;

namespace HubbersApp.Core.Services.Interfaces;

public interface IHubberService
{
    Task<IReadOnlyCollection<HubberDto>> GetAllHubbers();
}