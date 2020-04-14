using Newtonsoft.Json;

namespace QuizMaster.Repos
{
    public abstract class RepositoryItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}