using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork6
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? Title { get; set; } = "Неизвестно";
        public string? Author { get; set; } = "Неизвестно";
        public short PublicYear { get; set; }
        public string? Genre { get; set; } = "Неизвестно";
        private decimal _rating;
        public decimal Rating
        {
            get => _rating;
            set => _rating = Math.Clamp(value, 0, 10);
        }
        public bool IsAvailable { get; set; } = true;
    }
}
