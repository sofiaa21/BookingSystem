namespace HttpClients.ClientImpl;

using System.Text.Json;
using ClientInterfaces;
using Model;
using Model.DTOs;

public class ResourceService:IResourceService
{
    private readonly HttpClient client;

    public ResourceService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Resource>> GetAsync(string? name, int? quantity)
    {
        string query = ConstructQuery(name,quantity);

        HttpResponseMessage response = await client.GetAsync($"/Resource"+query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Resource> resources = JsonSerializer.Deserialize<ICollection<Resource>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return resources;


    }
    
    public async Task<ResourceGetByIdDto> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Resource/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ResourceGetByIdDto resource = JsonSerializer.Deserialize<ResourceGetByIdDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true

        })!;
        return resource;

    }


    private string ConstructQuery(string? name, int? quantity)
    {
        string query = "";
        if (!string.IsNullOrEmpty(name))
        {
            query += $"name={name}";
        }

        if (quantity != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"quantity={quantity}";
        }

        return query;
    }

}