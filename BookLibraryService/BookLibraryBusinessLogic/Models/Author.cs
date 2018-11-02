// <copyright file="Author.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Models
{
    /// <summary>
    /// Represents entity - Author of the book.
    /// </summary>
    public class Author : IClone<Author>
    {
        /// <summary>
        /// Serves for book id auto generation.
        /// </summary>
        private static int idCounter;

        /// <summary>
        /// Initializes static members of the
        /// <see cref="Author"/> class.
        /// </summary>
        static Author()
        {
            idCounter = 0;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Author"/> class.
        /// </summary>
        /// <param name="firstName">
        /// Author's first name.
        /// </param>
        /// <param name="lastName">
        /// Author's last name.
        /// </param>
        public Author(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Author"/> class.
        /// </summary>
        /// <param name="firstName">
        /// Author's first name.
        /// </param>
        /// <param name="lastName">
        /// Author's last name.
        /// </param>
        /// <param name="nickName">
        /// Author's nick name.
        /// </param>
        public Author(string firstName, string lastName, string nickName)
        {
            this.AuthorId = ++idCounter;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NickName = nickName;
        }

        /// <summary>
        /// Gets the author's identifier.
        /// </summary>
        public int AuthorId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets autor's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets autor's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets autor's nickname.
        /// </summary>
        /// <value>
        /// The name of the nick.
        /// </value>
        public string NickName { get; set; }

        /// <summary>
        /// Clones the info from source
        /// to object which run the method.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Clone(Author source)
        {
            idCounter--;
            this.FirstName = source.FirstName;
            this.LastName = source.LastName;
            this.NickName = source.NickName;
        }
    }
}
