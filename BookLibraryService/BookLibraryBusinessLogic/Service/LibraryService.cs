// <copyright file="LibraryService.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Represent book library service.
    /// </summary>
    /// <seealso cref="ILibraryService"/>
    public class LibraryService : ILibraryService
    {
        /// <summary>
        /// Provides service with data
        /// </summary>
        private readonly IDataProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        /// <param name="provider">The data provider.</param>
        public LibraryService(IDataProvider provider)
        {
            this.provider = provider;
        }

        #region BooksOperations

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>
        /// List of books.
        /// </returns>
        public List<Book> GetAllBooks()
        {
            return this.provider.Books;
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Concrete book.
        /// </returns>
        public Book GetBookById(int id)
        {
            Book targetBook = this.provider.Books.FirstOrDefault(b => b.BookId == id);
            return targetBook;
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Identifier of book has been added.
        /// </returns>
        public int AddBook(Book book)
        {
            this.provider.Books.Add(book);
            return book.BookId;
        }

        /// <summary>
        /// Removes the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool RemoveBook(int id)
        {
            bool isRemoved = false;

            Book targetBook = this.provider.Books.FirstOrDefault(b => b.BookId == id);
            if (targetBook != null)
            {
                this.provider.Books.Remove(targetBook);
                isRemoved = true;
            }

            return isRemoved;
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool UpdateBook(int id, Book book)
        {
            bool isUpdated = false;

            Book targetBook = this.provider.Books.FirstOrDefault(b => b.BookId == id);
            if (targetBook != null)
            {
                targetBook.Clone(book);
                isUpdated = true;
            }

            return isUpdated;
        }

        /// <summary>
        /// Removes the book autor.
        /// </summary>
        /// <param name="id">The identifier of the book.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool RemoveBookAutor(int id)
        {
            bool isRemoved = false;

            Book targetBook = this.provider.Books.FirstOrDefault(b => b.BookId == id);
            if (targetBook != null)
            {
                targetBook.AuthorId = null;
                isRemoved = true;
            }

            return isRemoved;
        }

        /// <summary>
        /// Adds the book author.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authorId">The author identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool AddBookAuthor(int id, int authorId)
        {
            bool isUpdated = false;

            Book targetBook = this.provider.Books.FirstOrDefault(b => b.BookId == id);
            if (targetBook != null)
            {
                targetBook.AuthorId = authorId;
                isUpdated = true;
            }

            return isUpdated;
        }

        #endregion

        #region AuthorsOperations

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns>
        /// List of authors.
        /// </returns>
        public List<Author> GetAllAuthors()
        {
            return this.provider.Authors;
        }

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Concrete author.
        /// </returns>
        public Author GetAuthorById(int id)
        {
            Author targetAuthor = this.provider.Authors.FirstOrDefault(a => a.AuthorId == id);
            return targetAuthor;
        }

        /// <summary>
        /// Adds the author.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>
        /// Identifier of author has been added.
        /// </returns>
        public int AddAuthor(Author author)
        {
            this.provider.Authors.Add(author);
            return author.AuthorId;
        }

        /// <summary>
        /// Updates the all information about the author.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="author">The author.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool UpdateAuthor(int id, Author author)
        {
            bool isUpdated = false;

            Author targetAuthor = this.provider.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (targetAuthor != null)
            {
                targetAuthor.Clone(author);
                isUpdated = true;
            }

            return isUpdated;
        }

        /// <summary>
        /// Removes the author by identifier
        /// and all his books from library.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        public bool RemoveAuthor(int id)
        {
            bool isRemoved = false;

            Author targetAuthor = this.provider.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (targetAuthor != null)
            {
                this.RemoveBooksCascade(id);
                this.provider.Authors.Remove(targetAuthor);
                isRemoved = true;
            }

            return isRemoved;
        }

        /// <summary>
        /// Removes the books of removed author cascade.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Number of deleted books.</returns>
        private int RemoveBooksCascade(int id)
        {
            return this.provider.Books.RemoveAll(b => b.AuthorId == id);
        }

        #endregion
    }
}
