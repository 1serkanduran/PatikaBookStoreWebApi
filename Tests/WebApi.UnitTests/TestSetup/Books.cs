using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDBContext context)
        {
            context.Books.AddRange
                (
                     new Book 
                     {
                         //Id = 1, 
                         Title = "Sherlok Holmes",
                         GenreId = 1, 
                         PageCount = 250,
                         PublishDate = new DateTime(2022, 5, 21) 
                     },
                     new Book 
                     {   
                        //Id = 2, 
                         Title = "Learn Reactjs",
                         GenreId = 2,
                         PageCount = 300,
                         PublishDate = new DateTime(2021, 2, 5)
                     },
                     new Book 
                     { 
                        // Id = 3,
                         Title = "C# beginner to advanced", 
                         GenreId = 3,
                         PageCount = 120,
                         PublishDate = new DateTime(2010, 3, 31)
                     }
                );
        }
    }
}