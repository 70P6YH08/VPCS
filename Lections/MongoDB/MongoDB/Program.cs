using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("Shop");

var products = database.GetCollection<BsonDocument>("products");

var phone = new BsonDocument
{
    { "name", "Iphone 18" },
    { "price", 125000 },
    { "memory", 512 },
    { "camera", 24 }
};

var laptop = new BsonDocument
{
    {"name", "Aser Nitro Lite" },
    {"price", 60000 },
    {"processor", "Intel Core i5" },
    {"ram", 16 },
};

products.InsertOne(phone);
products.InsertOne(laptop);

//var student = new Student()
//{
//    Name = "Наумов Николай Александрович",
//    Group = "Лучшая-01",
//    Avg = 5.5
//};

//students.InsertOne(student);

//var result = students.Find(_ => true).ToList(); //find all students


//foreach (var student in result)
//{
//    Console.WriteLine($"{student.Name}, {student.Group}, [{student.Avg}]");
//}


var results = products.Find(new BsonDocument()).ToList();
foreach(var result in results)
{
    BsonDocument product = result;
    products.UpdateOne(_ => _["name"] == result["name"],
        Builders<BsonDocument>.Update.Set(_ => _["comment"], "empty comment"));
    //products.DeleteOne()
    if (result.Contains("processor"))
        Console.WriteLine(result["name"]);
}