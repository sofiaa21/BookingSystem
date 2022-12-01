namespace DataAccess.DAOs.interf;

using Model;
using Model.DTOs;

public interface IResourceDao
{
    Task<IEnumerable<Resource>> GetAsync(ResourceDto resource);
    Task<Resource?> GetByIdAsync(int id);
}