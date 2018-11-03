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
        /// Serves for BookId auto generation.
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
        /// <param name="authorId">AuthorId foreign key.</param>
        public Book(DateTime date, string title, int? authorId = null)
        {
            this.BookId = ++idCounter;
            this.AuthorId = authorId;
            this.Title = title;
            this.PublicationDate = date;
        }

        /// <summary>
        /// Gets or sets id of the book,
        /// which have status of primary key in this table.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the author's identifier,
        /// which have status of foreign key in this table.
        /// </summary>
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
        /// Clones the information from source object
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

        /// <summary>
        /// Determines whether the specified
        /// <see cref="object"/>,is equal to this instance.
        /// </summary>
        /// <param name="targetObject">
        /// The <see cref="object"/> to compare with this instance.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" />
        /// is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object targetObject)
        {
            bool result = false;

            if (targetObject is Book)
            {
                Book book = targetObject as Book;
                if (book.BookId == this.BookId && book.AuthorId == this.AuthorId)
                {
                    if (book.Title == this.Title)
                    {
                        if (book.PublicationDate == this.PublicationDate)
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance,
        /// suitable for use in hashing algorithm
        /// and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }
    }
}
