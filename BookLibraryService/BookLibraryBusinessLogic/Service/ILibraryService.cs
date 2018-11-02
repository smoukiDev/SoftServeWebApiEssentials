// <copyright file="ILibraryService.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Service
{
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Provides CRUD method prototypes
    /// for manage book library.
    /// </summary>
    public interface ILibraryService : IBook, IAuthor
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>List of books.</returns>
        List<Book> GetAllBooks();

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns>List of authors.</returns>
        List<Author> GetAllAuthors();
    }
}
