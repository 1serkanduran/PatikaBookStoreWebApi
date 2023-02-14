using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDBContext context)
        {
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
        }
    }
}