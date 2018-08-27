using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreProject.LeprosyModel;
using GenFu;

namespace AspNetCoreProject.Repositories
{
    public class BookRepository : IBookRepository
    {

        private IEnumerable<Book> _books = new List<Book>();
        private IEnumerable<Author> _authors = new List<Author>();
        private IEnumerable<Publisher> _publisher = new List<Publisher>();


        public BookRepository()
        {
            GenFu.GenFu.Configure<Author>()
               .Fill(_ => _.Name)
               .AsLastName()
               .Fill(_ => _.Birthdate)
               .AsPastDate();
            
            _authors = GenFu.GenFu.ListOf<Author>(40);


            GenFu.GenFu.Configure<Publisher>()
                .Fill(_ => _.Name)
                .AsMusicArtistName();
            
            _publisher = GenFu.GenFu.ListOf<Publisher>(10);

            GenFu.GenFu.Configure<Book>()
               .Fill(p => p.Isbn)
               .AsPhoneNumber()
               .Fill(p => p.Name)
               .AsLoremIpsumWords(5)
               .Fill(p => p.Author)
               .WithRandom(_authors)
               .Fill(_ => _.Publisher)
               .WithRandom(_publisher);


            _books = GenFu.GenFu.ListOf<Book>(100);

        }


        public IEnumerable<Author> AllAuthors()
        {
            return _authors;
        }

        public IEnumerable<Book> AllBooks(int limit)
        {
            return _books.Take(limit);
        }

        public IEnumerable<Publisher> AllPublishers()
        {
            return _publisher;
        }

        public Author AuthorById(int id)
        {
            return _authors.First(_ => _.Id == id);
        }

        public Book BookByIsbn(string isbn)
        {
            return _books.First(_ => _.Isbn == isbn);
        }

        public Publisher PublisherById(int id)
        {
            return _publisher.First(_ => _.Id == id);

        }

       public Book AddBook(Book newBook){

            var book = new Book()
            {
                Name = "Haile",
                Isbn = "xyz"
            };

            return book;
        }

    }
}
