// <copyright file="LibraryDataProvider.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Data
{
    using System;
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Represents data provider for library service.
    /// </summary>
    /// <seealso cref="BookLibraryBusinessLogic.Data.IDataProvider" />
    public class LibraryDataProvider : IDataProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDataProvider"/> class.
        /// </summary>
        public LibraryDataProvider()
        {
            int counter = 0;
            this.Authors = new List<Author>()
            {
                new Author(++counter, "Daniel", "Abraham", "James Corey"),
                new Author(++counter, "Michael", "Dobbs"),
                new Author(++counter, "Andrew", "Troelsen"),
                new Author(++counter, "Dmitry", "Glukhovsky")
            };

            counter = 0;
            this.Books = new List<Book>()
            {
                new Book(++counter, new DateTime(2011, 06, 15), "Leviathan Wakes",  1),
                new Book(++counter, new DateTime(2016, 12, 10), "Metro 2035",  4),
                new Book(++counter, new DateTime(2017, 03, 03), "Pro C# 7 - With .NET and .NET Core",  3),
                new Book(++counter, new DateTime(1989, 07, 07), "House of cards",  2),
            };
        }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        public List<Author> Authors { get; set; }
    }
}
