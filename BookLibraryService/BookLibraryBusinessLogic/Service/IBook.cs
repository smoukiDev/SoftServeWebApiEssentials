// <copyright file="IBook.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Service
{
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Provides CRUD method prototypes
    /// to manage books in library.
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Identifier of book has been added</returns>
        int AddBook(Book book);

        /// <summary>
        /// Updates the all information of the book.
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
        /// Removes the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        bool RemoveBook(int id);

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Concrete book</returns>
        Book GetBookById(int id);

        /// <summary>
        /// Removes the book autor.
        /// </summary>
        /// <param name="id">The identifier of the book.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        bool RemoveBookAutor(int id);

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
        bool AddBookAuthor(int id, int authorId);
    }
}