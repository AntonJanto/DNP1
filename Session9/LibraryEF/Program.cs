using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibraryEF.DataAccess;
using LibraryEF.Models;

namespace LibraryEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //var addedBook = AddBookGenreAuthorAsync();
            //Console.WriteLine("Adding book to database");

            //var addedAuthor = AddAuthorAsync();
            //Console.WriteLine("Adding author to database");

            var addedBookWithAuthor = AddBookToAuthorAsync();
            Console.WriteLine("Adding book with author to database");

            int i = 0;
            while (!addedBookWithAuthor.IsCompleted)
            {
                Console.WriteLine(i++);
                Thread.Sleep(100);
            }


            //Console.WriteLine("Book added");
            //Console.WriteLine("Author added");
            Console.WriteLine("Book with author added");

        }

        private static async Task AddBookGenreAuthorAsync()
        {
            var genre = new Genre
            {
                GenreName = "High fantasy"
            };

            var author = new Author
            {
                FirstName = "Brandon",
                LastName = "Sanderson",
                Bio = "I write good stuff"
            };

            var book = new Book
            {
                Author = author,
                Genre = genre,
                Title = "The way of kings",
                ISBN = 0765326353,
                PublishDate = new DateTime(2010, 7, 31),
                TotalPages = 1007
            };

            using (var libContext = new LibraryContext())
            {
                libContext.Books.Add(book);
                await libContext.SaveChangesAsync();
            }
        }

        private static async Task AddAuthorAsync()
        {
            var author = new Author
            {
                FirstName = "Stephen",
                LastName = "King",
                Bio = "I am pretty famous"
            };

            using (var libContext = new LibraryContext())
            {
                libContext.Authors.Add(author);
                await libContext.SaveChangesAsync();
            }
        }

        private static async Task AddBookToAuthorAsync()
        {
            using (var libcontext = new LibraryContext())
            {
                var authorSK = libcontext.Authors.First(a => a.FirstName == "Stephen" && a.LastName == "King");
                var book = new Book
                {
                    Title = "The Shining",
                    ISBN = 0450040186,
                    PublishDate = new DateTime(1980, 1, 28),
                    TotalPages = 659,
                    Author = authorSK
                };

                libcontext.Books.Add(book);
                await libcontext.SaveChangesAsync();
            }
        }
    }
}
