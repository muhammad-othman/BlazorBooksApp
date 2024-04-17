using Amazon.DynamoDBv2.DataModel;

namespace BlazorBooksApp
{
    [DynamoDBTable("Book")]
    public class Book
    {
        [DynamoDBHashKey]
        public int Id { get; set; }

        public string Title { get; set; }
        public int ISBN { get; set; }

        [DynamoDBProperty("Authors")]
        public List<string> BookAuthors { get; set; }

        public string DownloadLink { get; set; }
    }
}