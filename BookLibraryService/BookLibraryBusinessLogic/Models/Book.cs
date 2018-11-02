// <copyright file="Book.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Models
{
    using System;

    /// <summary>
    /// Represents model of book.
    /// </summary>
    public class Book : IClone<Book>
    {
        /// <summary>
        /// Serves for book id auto generation.
        /// </summary>
        private static int idCounter;

        /// <summary>
        /// Initializes static members of the <see cref="Book"/> class.
        /// </summary>
        static Book()
        {
            idCounter = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author of book.</param>
        /// <param name="title">Title of book.</param>
        /// <param name="date">Publication date.</param>
        public Book(string author, string title, DateTime date)
        {
            this.Id = ++idCounter;
            this.Author = author;
            this.Title = title;
            this.PublicationDate = date;
        }

        /// <summary>
        /// Gets id of the book.
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets publication date of the book.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Clones the info from source
        /// to object which run the method.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Clone(Book source)
        {
            idCounter--;
            this.Author = source.Author;
            this.Title = source.Title;
            this.PublicationDate = source.PublicationDate;
        }
    }
}
