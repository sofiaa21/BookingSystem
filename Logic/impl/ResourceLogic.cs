namespace Logic.impl;

using DataAccess.DAOs.interf;
using Model;
using Model.DTOs;

public class ResourceLogic:IResourceLogic
{
    private readonly IResourceDao resourceDao;

    public ResourceLogic(IResourceDao resourceDao)
    {
        this.resourceDao = resourceDao;
    }

    public Task<IEnumerable<Resource>> GetAsync(ResourceDto resource)
    {
        return resourceDao.GetAsync(resource);
    }

    public async Task<ResourceGetByIdDto> GetByIdAsync(int id)
    {
        Resource? resource = await resourceDao.GetByIdAsync(id);
        if (resource == null)
        {
            throw new Exception($"Resource with id{id} does not exist");
        }

        return new ResourceGetByIdDto(resource.Id,resource.Name, resource.Quantity);
    }
}