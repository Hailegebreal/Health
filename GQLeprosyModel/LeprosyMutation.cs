using System;
using AspNetCoreProject.LeprosyModel;
using AspNetCoreProject.Repositories;
using GraphQL.Types;


namespace AspNetCoreProject.GQLeprosyModel
{
    public class LeprosyMutation: ObjectGraphType
    {
        

        public LeprosyMutation(IBookRepository bookrepository)
            {
            Name = "Mutation";

                Field<BookType>("createBook",
                                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookInputType>>() { Name = "newbook" }),
                      resolve: conz =>
                      {
                          var newBook = conz.GetArgument<Book>("newbook");
                          return bookrepository.AddBook(newBook);
                      });


            }

    }


    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "bookInput";

            Field<NonNullGraphType<StringGraphType>>("Isbn");

            Field<StringGraphType>("Name");



        }
    }


}
