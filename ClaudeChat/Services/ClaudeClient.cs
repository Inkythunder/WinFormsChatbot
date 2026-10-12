using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ClaudeChat.Services;

public class ChatTurn
{
    public string Role { get; }
    public string Content { get; }

    public ChatTurn(string role, string content)
    {
        Role = role;
        Content = content;
    }
}

public class ClaudeApiException : Exception
{
    public int StatusCode { get; }
    public string? ErrorType { get; }

    public ClaudeApiException(int statusCode, string? errorType, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorType = errorType;
    }
}

/// <summary>
/// Wrapper around HttpClient that knows how to call Claude Messages API.
/// </summary>
public class ClaudeClient
{
    private readonly HttpClient _http;

    public ClaudeClient(string apiKey)
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri("https://api.anthropic.com/"),
            Timeout = TimeSpan.FromMinutes(10)
        };

        _http.DefaultRequestHeaders.Add("x-api-key", apiKey);

        _http.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");

        _http.DefaultRequestHeaders.Accept.ParseAdd("application/json");
    }

    public async Task<string> SendAsync(IReadOnlyList<ChatTurn> history, CancellationToken ct = default)
    {
        var request = BuildRequest(history);

        using var response = await _http.PostAsJsonAsync("v1/messages", request, ct);
        var body = await response.Content.ReadAsStringAsync(ct);

        if(!response.IsSuccessStatusCode)
        {
            throw ParseError((int)response.StatusCode, body);
        }

        using var doc = JsonDocument.Parse(body);
        var root = doc.RootElement;

        var text = "";
        foreach (var block in root.GetProperty("content").EnumerateArray())
        {
            if(block.GetProperty("type").GetString() == "text")
            {
                text += block.GetProperty("text").GetString();
            }
        }

        if (text.Length == 0)
        {
            var stopReason = root.GetProperty("stop_reason").GetString();
            text = $"[Claude returned no Text. Stop reason: {stopReason}]";
        }

        return text;
    }

    private static JsonObject BuildRequest(IReadOnlyList<ChatTurn> history)
    {
        var messages = new JsonArray();
        foreach (var turn in history)
        {
            messages.Add(new JsonObject
            {
                ["role"] = turn.Role,
                ["content"] = turn.Content
            });
        }

        return new JsonObject
        {
            ["model"] = "claude-opus-5-5",
            ["max_tokens"] = 16000,
            ["messages"] = messages
        };
    }

    private static ClaudeApiException ParseError(int statusCode, string body)
    {
        try
        {
            using var doc = JsonDocument.Parse(body);
            var error = doc.RootElement.GetProperty("error");

            return new ClaudeApiException(
                statusCode,
                error.GetProperty("type").GetString(),
                error.GetProperty("message").GetString() ?? body
            );
        }
        catch (Exception)
        {
            return new ClaudeApiException(statusCode, null, body);
        }
    }
}
