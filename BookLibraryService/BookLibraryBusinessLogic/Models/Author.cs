// <copyright file="Author.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Models
{
    /// <summary>
    /// Represents entity Author.
    /// </summary>
    public class Author : IClone<Author>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        /// <param name="authorId">Author identifier.</param>
        /// <param name="firstName">Author's first name.</param>
        /// <param name="lastName">Author's last name.</param>
        public Author(int authorId, string firstName, string lastName)
            : this(authorId, firstName, lastName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        /// <param name="authorId">Author identifier.</param>
        /// <param name="firstName">Author's first name.</param>
        /// <param name="lastName">Author's last name.</param>
        /// <param name="nickName">Author's nickname.</param>
        public Author(int authorId, string firstName, string lastName, string nickName)
        {
            this.AuthorId = authorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NickName = nickName;
        }

        /// <summary>
        /// Gets or sets the author's identifier.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets author's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets author's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets author's nickname.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Clones the information from source object to object which runs the method.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Clone(Author source)
        {
            this.FirstName = source.FirstName;
            this.LastName = source.LastName;
            this.NickName = source.NickName;
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

            if (targetObject is Author)
            {
                Author author = targetObject as Author;
                if (author.AuthorId == this.AuthorId)
                {
                    if (author.FirstName == this.FirstName)
                    {
                        if (author.LastName == this.LastName)
                        {
                            if (author.NickName == this.NickName)
                            {
                                result = true;
                            }
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
            return this.LastName.GetHashCode();
        }
    }
}
