using System.Text.Json.Serialization;

namespace AthatyCore.Entities
{
    //This entity is used to register users of the API
    public record User
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string UserName { get; init; }

        //This annotation prevents Password from being serialized and sent as HTTP repsonse
        [JsonIgnore]
        public string Password { get; init; }
    }
}
