using System;
using AspNetCoreProject.LeprosyModel;
using AspNetCoreProject.Repositories;
using GraphQL;
using GraphQL.Types;

namespace AspNetCoreProject.GQLeprosyModel
{
    public class BookQuery:ObjectGraphType
    {
        public BookQuery(IBookRepository bookrepository)
        {
            Field<BookType>("book",
                  arguments: new QueryArguments(new QueryArgument<StringGraphType>() { Name = "isbn" }),
                  resolve: conz =>
                  {
                      var id = conz.GetArgument<string>("isbn");
                      return bookrepository.BookByIsbn(id);
                  });

            Field<ListGraphType<BookType>>("books",
                                           arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "limit" }),
                                           resolve: conx =>
            {
                var limit = conx.GetArgument<int>("limit");

                var bookx = bookrepository.AllBooks(limit);

                return bookrepository.AllBooks(limit);
            });
                                           
        }
    }


    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Isbn).Description("The isbn of the book.");
            Field(x => x.Name).Description("The name of the book.");
            Field<AuthorType>("author");
        }
    }

    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Name).Description("The name of the author.");
            Field(x => x.Birthdate).Description("The name of the Birthdate.");
           
        }
    }





}
