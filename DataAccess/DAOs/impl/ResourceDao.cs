namespace DataAccess.DAOs.impl;

using interf;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;

public class ResourceDao:IResourceDao
{
    private readonly DbBookingSystemContext context;

    public ResourceDao(DbBookingSystemContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Resource>> GetAsync(ResourceDto resource)
    {
        IQueryable<Resource> query = context.Resources.AsQueryable();
        if (resource.Name != null)
        {
            query = query.Where(
                r => r.Name.ToLower().Contains(resource.Name.ToLower()));
            
        }

        if (resource.Quantity != null)
        {
            query = query.Where(r => r.Quantity == resource.Quantity);
        }

        IEnumerable<Resource> result = await query.ToListAsync();
        return result;
    }

    public async Task<Resource?> GetByIdAsync(int id)
    {
        Resource? resource = await context.Resources.SingleOrDefaultAsync(resource => resource.Id == id);
        return resource;
    }
}