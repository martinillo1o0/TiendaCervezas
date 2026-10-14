using System.Text.Json;
using backend.DTOs;

namespace backend.services;

public class PostService : IPostService
{
    private readonly HttpClient _httpClient;

    public PostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PostDTO>> Get()
    {
        var result = await _httpClient.GetAsync(string.Empty);
        var body = await result.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var posts = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);
        return posts ?? Enumerable.Empty<PostDTO>();
    }
}
