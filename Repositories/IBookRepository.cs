using System;
using System.Collections.Generic;
using AspNetCoreProject.LeprosyModel;

namespace AspNetCoreProject.Repositories
{
    public interface IBookRepository
    {
        Book BookByIsbn(string isbn);

        IEnumerable<Book> AllBooks(int limit);

        Author AuthorById(int id);

        Book AddBook(Book newBook);

        IEnumerable<Author> AllAuthors();

        Publisher PublisherById(int id);

        IEnumerable<Publisher> AllPublishers();



    }
}
