using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange
                (
                    new Author
                    {
                        Name="Tolstoy",
                        Surname="Tols",
                        DateOfBirth=new DateTime(1890,10,15)
                    },   
                    new Author
                    {
                        Name="Dostoyevski",
                        Surname="Dosto",
                        DateOfBirth=new DateTime(1890,10,15)
                    },
                    new Author
                    {
                        Name="Gabriel",
                        Surname="Marquez",
                        DateOfBirth=new DateTime(1890,10,15)
                    }                 
                );
                context.Genres.AddRange
                (
                    new Genre
                    {
                        Name="Personel Growth"
                    },
                    new Genre
                    {
                        Name="Science Fiction"
                    },
                    new Genre
                    {
                        Name="Romance"
                    }                    
                );
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
                context.SaveChanges();
            }

        }
    }
}