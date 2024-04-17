using Amazon.DynamoDBv2.DataModel;

namespace BlazorBooksApp
{
    [DynamoDBTable("BooksDataTable")]
    public class Book
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public int ISBN { get; set; }

        public string Author { get; set; }

        [DynamoDBIgnore]
        public string DownloadLink { get; set; }

        public S3Link? S3Link { get; set; }
    }


    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public int ISBN { get; set; }

        public string Author { get; set; }
    }
}