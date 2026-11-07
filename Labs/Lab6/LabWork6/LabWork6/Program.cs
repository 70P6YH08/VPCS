using LabWork6;
using MongoDB.Driver;

var client = new MongoClient("mongodb://localhost:27017");

var db = client.GetDatabase("Library");
var books = db.GetCollection<Book>("Books");

while (true)
{
    Console.WriteLine("Хотите добавить книгу? [по умолчанию ДА]");
    var agree = Console.ReadLine();
    if (agree.ToLower().Equals("нет"))
        break;

    Console.Write("Введите название книги: ");
    var bookTitle = Console.ReadLine();

    Console.Write("Введите автора книги: ");
    var bookAuthor = Console.ReadLine();

    Console.Write("Введите год издаиня книги: ");

    short bookPublicYear = 0;
    try
    {
        bookPublicYear = (short)Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Неверный формат года. {ex.Message}");
        continue;
    }

    Console.WriteLine("Введите жанр книги: ");

    Dictionary<string, string> genres = new()
    {
        { "1","Детектив"},
        { "2", "Фантастика"},
        { "3","Ужасы"},
        { "5","Приключения"},
        { "6","Стимпанк"},
        { "7","Ода"},
        { "8","Поэма"},
        { "9","Прозма"},
        { "10","Сказка"},
        { "11","Романтика"},
        { "12","Биография"},
    };

    foreach (var genre in genres)
        Console.WriteLine($"[{genre.Key}] - [{genre.Value}]");

    var bookGenreKey = Console.ReadLine()!;
    var bookGenre = genres[bookGenreKey];

    Console.Write("Введите рейтинг книги: ");
    var bookRating = Convert.ToInt32(Console.ReadLine());

    await books.InsertOneAsync(new Book
    {
        Title = bookTitle,
        Author = bookAuthor,
        PublicYear = bookPublicYear,
        Genre = bookGenre,
        Rating = bookRating
    });
}

var allBooks = books.Find(_ => true).ToList();
foreach (var book in allBooks)
{
    Console.WriteLine($"ID: {book.Id}" +
        $"- НАЗВАНИЕ: {book.Title}" +
        $"- АВТОР: {book.Author}" +
        $"- ГОД ПУБЛИКАЦИИ: {book.PublicYear}" +
        $"- ЖАНР: {book.Genre}" +
        $"- РЕЙТИНГ: {book.Rating}" +
        $"- ДОСТУПНОСТЬ: {book.IsAvailable}\n");
}