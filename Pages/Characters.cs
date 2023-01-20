using BlazorAPIClient.DataServices;
using BlazorAPIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAPIClient.Pages;

public partial class Characters
{
    [Inject]
    private IRickAndMortyDataService _RickAndMortyDataService { get; set; } 

    private CharacterDto[]? _characters;

    protected override async Task OnInitializedAsync()
    {
        _characters = await _RickAndMortyDataService.GetAllCharacters();
    }
}