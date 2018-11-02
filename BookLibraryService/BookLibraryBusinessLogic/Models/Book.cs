// <copyright file="Book.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Models
{
    using System;

    /// <summary>
    /// Represents entity Book.
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
        /// <param name="title">Title of book.</param>
        /// <param name="date">Publication date.</param>
        /// <param name="authorId">Author Id reference.</param>
        public Book(string title, DateTime date, int? authorId = null)
        {
            this.Id = ++idCounter;
            this.AuthorId = authorId;
            this.Title = title;
            this.PublicationDate = date;
        }

        /// <summary>
        /// Gets id of the book,
        /// which have status of primary key in this table.
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the author's identifier,
        /// which have status of foreign key in this table.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        public int? AuthorId { get; set; }

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
            this.AuthorId = source.AuthorId;
            this.Title = source.Title;
            this.PublicationDate = source.PublicationDate;
        }
    }
}
