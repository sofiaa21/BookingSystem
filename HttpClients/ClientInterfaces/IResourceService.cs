namespace HttpClients.ClientInterfaces;

using Model;
using Model.DTOs;

public interface IResourceService
{
    Task<ICollection<Resource>> GetAsync(string? name=null, int? quantity=null);
    Task<ResourceGetByIdDto> GetByIdAsync(int id);
}