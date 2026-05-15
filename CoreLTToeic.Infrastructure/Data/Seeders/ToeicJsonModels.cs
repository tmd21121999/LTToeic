using System.Text.Json.Serialization;

namespace CoreLTToeic.Infrastructure.Data.Seeders;

public class ToeicCardJson
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("hasChild")]
    public int HasChild { get; set; }

    [JsonPropertyName("question")]
    public ToeicQuestionJson Question { get; set; } = new();

    [JsonPropertyName("answer")]
    public ToeicAnswerJson Answer { get; set; } = new();

    [JsonPropertyName("type")]
    public long Type { get; set; }

    [JsonPropertyName("orderIndex")]
    public long OrderIndex { get; set; }

    [JsonPropertyName("childCards")]
    public List<ToeicCardJson> ChildCards { get; set; } = new();
}

public class ToeicQuestionJson
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = "";

    [JsonPropertyName("image")]
    public string Image { get; set; } = "";

    [JsonPropertyName("sound")]
    public string Sound { get; set; } = "";
}

public class ToeicAnswerJson
{
    [JsonPropertyName("texts")]
    public List<string> Texts { get; set; } = new();

    [JsonPropertyName("choices")]
    public List<string> Choices { get; set; } = new();

    [JsonPropertyName("hint")]
    public string Hint { get; set; } = "";
}
