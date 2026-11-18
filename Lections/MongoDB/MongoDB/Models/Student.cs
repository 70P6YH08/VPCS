using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("full_name")]
        public string? Name { get; set; }

        [BsonElement("group")]
        public string? Group {  get; set; }

        [BsonElement("avg")]
        public double Avg { get; set; }

        [BsonElement("comment")]
        public string? Comment { get; set; }
    }
}
