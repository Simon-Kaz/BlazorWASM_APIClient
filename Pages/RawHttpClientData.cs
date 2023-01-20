using System.Net.Http.Json;
using BlazorAPIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAPIClient.Pages;

public partial class RawHttpClientData
{
    [Inject]
    private HttpClient Http { get; set; }

    private CharacterDto[]? _characters;

    protected override async Task OnInitializedAsync()
    {
        var result = await Http.GetFromJsonAsync<CharactersDto>("api/character");
        _characters = result?.Characters;
    }
}