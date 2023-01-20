using System.Text;
using System.Text.Json;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices;

public class GraphQLRickAndMortyDataService : IRickAndMortyDataService
{
    private readonly HttpClient _client;

    public GraphQLRickAndMortyDataService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<CharacterDto[]?> GetAllCharacters()
    {
        var queryObject = new
        {
            query = @"query {characters { results { id name gender species origin { name } status location {name } } } }",
            variables = new { }
        };
        var characterQuery = new StringContent(JsonSerializer.Serialize(queryObject), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("graphql", characterQuery);

        if (response.IsSuccessStatusCode)
        {
            var gqlData = await JsonSerializer.DeserializeAsync<GqlData>
                (await response.Content.ReadAsStreamAsync());

            return gqlData?.Data.CharactersData.Characters;
        }

        return null;
    }
}