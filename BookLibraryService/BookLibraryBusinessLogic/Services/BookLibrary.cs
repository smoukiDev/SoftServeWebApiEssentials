// <copyright file="BookLibrary.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Represent book library service.
    /// </summary>
    /// <seealso cref="BookLibraryBusinessLogic.Services.IBookLibrary" />
    public class BookLibrary : IBookLibrary
    {
        /// <summary>
        /// The books in the library.
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookLibrary"/> class.
        /// </summary>
        /// <param name="provider">The data provider.</param>
        public BookLibrary(IDataProvider provider)
        {
            this.books = provider.GetDefaultBooks().ToList();
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Id of book has been added.
        /// </returns>
        public int AddBook(Book book)
        {
            this.books.Add(book);
            return book.Id;
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

            Book bookToRemove = this.books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                this.books.Remove(bookToRemove);
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

            Book bookToUpdate = this.books.FirstOrDefault(b => b.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Clone(book);
                isUpdated = true;
            }

            return isUpdated;
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
            Book targetBook = this.books.FirstOrDefault(b => b.Id == id);

            return targetBook;
        }

        /// <summary>
        /// Gets the all books of library.
        /// </summary>
        /// <returns>
        /// All books in library.
        /// </returns>
        public IEnumerable<Book> GetLibraryBooks()
        {
            return this.books;
        }
    }
}
