using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices;

public interface IRickAndMortyDataService
{
    Task<CharacterDto[]?> GetAllCharacters();
}