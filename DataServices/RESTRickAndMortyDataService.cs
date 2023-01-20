using System.Net.Http.Json;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices;

public class RESTRickAndMortyDataService : IRickAndMortyDataService
{
    private readonly HttpClient _client;

    public RESTRickAndMortyDataService(HttpClient client)
    {
        _client = client;
    }
    public async Task<CharacterDto[]?> GetAllCharacters()
    {
        var result = await _client.GetFromJsonAsync<CharactersDto>("/api/character");
        return result?.Characters; 
    }
}