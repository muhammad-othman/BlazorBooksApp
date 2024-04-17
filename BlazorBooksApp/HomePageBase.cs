using Microsoft.AspNetCore.Components;

namespace BlazorBooksApp;

public class HomePageBase : ComponentBase
{
    public List<Book> Books { get; set; }
    protected override void OnInitialized()
    {
        Books = new List<Book>()
        {
            new Book
            {
                Id = 10,
            },

            new Book
            {
                Id = 11,
            },

            new Book
            {
                Id = 12,
            },
        };
    }
}