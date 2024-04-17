using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBooksApp
{
    public class BooksService
    {
        private readonly DynamoDBContext dynamoDBContext;

        public BooksService(DynamoDBContext dynamoDBContext)
        {
            this.dynamoDBContext = dynamoDBContext;
        }

        public async Task<Book> CreateBook(Book book, IBrowserFile file)
        {
            book.Id = Guid.NewGuid();
            book.S3Link = S3Link.Create(dynamoDBContext, "aws-net-sdk-1007260863", file.Name, Amazon.RegionEndpoint.USEast1);
            
            await dynamoDBContext.SaveAsync(book);
            await book.S3Link.UploadStreamAsync(file.OpenReadStream());

            return book;
        }

        public async Task Delete(Book book)
        {
            await dynamoDBContext.DeleteAsync<Book>(book.Id);
        }


        public async Task Update(Book book)
        {
            await dynamoDBContext.SaveAsync(book);
        }

        public async Task<Book> GetBook(Guid id)
        {
            var bookRetrieved = await dynamoDBContext.LoadAsync<Book>(id);
            if (bookRetrieved.S3Link != null)
                bookRetrieved.DownloadLink = bookRetrieved.S3Link.GetPreSignedURL(DateTime.Now.AddHours(5));
            return bookRetrieved;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var conditions = new List<ScanCondition>();
            // you can add scan conditions, or leave empty
            var retrievedBooks = await dynamoDBContext.ScanAsync<Book>(conditions).GetRemainingAsync();
            retrievedBooks.ForEach(book =>
            {
                if (book.S3Link != null)
                    book.DownloadLink = book.S3Link.GetPreSignedURL(DateTime.Now.AddHours(5));
            });
            return retrievedBooks;
        }

    }
}
