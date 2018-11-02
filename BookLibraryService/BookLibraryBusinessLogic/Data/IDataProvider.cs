// <copyright file="IDataProvider.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Data
{
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Provides default set of data for models.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Gets the default set of books.
        /// </summary>
        /// <returns>Enumaration of books.</returns>
        List<Book> GetDefaultBooks();
    }
}
