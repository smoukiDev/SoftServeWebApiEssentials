// <copyright file="IAuthor.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Service
{
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Provides CRUD method prototypes
    /// to manage authors in library.
    /// </summary>
    public interface IAuthor
    {
        /// <summary>
        /// Adds the author.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>Identifier of author has been added.</returns>
        int AddAuthor(Author author);

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
        bool UpdateAuthor(int id, Author author);

        /// <summary>
        /// Removes the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Operation success,
        /// true - successful updated
        /// false - if not.
        /// </returns>
        bool RemoveAuthor(int id);

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Concrete author.</returns>
        Author GetAuthorById(int id);
    }
}