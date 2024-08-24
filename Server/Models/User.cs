namespace Server.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        //TODO Find a way to initialise Social links in this model, via Dictionary or find a noSQl replacement for many:1
        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime? CreatedAt { get; set; }
        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime? UpdatedAt { get; set; }
        }
}