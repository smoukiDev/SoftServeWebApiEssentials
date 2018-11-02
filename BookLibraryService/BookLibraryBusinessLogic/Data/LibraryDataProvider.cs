// <copyright file="LibraryDataProvider.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Data
{
    using System;
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Represents data provider for book library service.
    /// </summary>
    /// <seealso cref="BookLibraryBusinessLogic.Data.IDataProvider" />
    public class LibraryDataProvider : IDataProvider
    {
        /// <summary>
        /// Gets the default set of books.
        /// </summary>
        /// <returns>
        /// Enumaration of books.
        /// </returns>
        public IEnumerable<Book> GetDefaultBooks()
        {
            // Initialization of the book storage
            List<Book> books = new List<Book>()
            {
                new Book("James Corey", "Leviathan Wakes", new DateTime(2011, 06, 15)),
                new Book("Dmitry Glukhovsky", "Metro 2035", new DateTime(2016, 12, 10)),
                new Book("Andrew Troelsen", "Pro C# 7 - With .NET and .NET Core", new DateTime(2017, 03, 03))
            };

            return books;
        }
    }
}
