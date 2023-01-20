using System.Text.Json.Serialization;

namespace BlazorAPIClient.Dtos;


public partial class GqlData
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public partial class Data
{
    [JsonPropertyName("characters")]
    public CharactersData CharactersData { get; set; }
}

public partial class CharactersData
{
    [JsonPropertyName("results")]
    public CharacterDto[] Characters { get; set; }
}