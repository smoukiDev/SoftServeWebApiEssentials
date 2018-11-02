// <copyright file="IBookLibrary.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Services
{
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Provides CRUD method prototypes
    /// for book library service.
    /// </summary>
    public interface IBookLibrary
    {
        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Id of book has been added</returns>
        int AddBook(Book book);

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
        bool UpdateBook(int id, Book book);

        /// <summary>
        /// Removes the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        bool RemoveBook(int id);

        /// <summary>
        /// Gets the library books.
        /// </summary>
        /// <returns>All books in library</returns>
        List<Book> GetLibraryBooks();

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Concrete book</returns>
        Book GetBookById(int id);
    }
}
