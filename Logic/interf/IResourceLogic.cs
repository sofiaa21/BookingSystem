namespace Logic;

using Model;
using Model.DTOs;

public interface IResourceLogic
{
    public Task<IEnumerable<Resource>> GetAsync(ResourceDto resource);
    Task<ResourceGetByIdDto> GetByIdAsync(int id);
}