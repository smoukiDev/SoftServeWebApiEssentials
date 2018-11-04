// <copyright file="LibraryServiceTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Models;
    using BookLibraryBusinessLogic.Service;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Provides Test Methods for class LibraryService
    /// aimed on books management functionality.
    /// </summary>
    [TestClass]
    public class LibraryServiceTests
    {
        /// <summary>
        /// List of default books to use
        /// mocking IDataProvider.
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List of default authors to use
        /// mocking IDataProvider.
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// LibraryService object under testing.
        /// </summary>
        private LibraryService libraryService;

        /// <summary>
        /// IDataProvider Mock.
        /// </summary>
        private Mock<IDataProvider> mockDataProvider;

        /// <summary>
        /// Initialize required object before start of
        /// every test method.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            int counter = 0;
            this.books = new List<Book>()
            {
                new Book(++counter, new DateTime(2017,07,07),"Title1", 3),
                new Book(++counter, new DateTime(2018,08,08),"Title2", 1),
                new Book(++counter, new DateTime(2016,06,06),"Title3", 2)
            };

            counter = 0;
            this.authors = new List<Author>()
            {
                new Author(++counter, "FirstName1","LastName1"),
                new Author(++counter, "FirstName2","LastName2", null),
                new Author(++counter, "FirstName3","LastName3", "NickName"),
            };

            this.mockDataProvider = new Mock<IDataProvider>();
        }

        #region BooksManagementTestMethods

        /// <summary>
        /// Checks whether method GetAllBooks
        /// return collection of all available books correctly.
        /// </summary>
        [TestMethod]
        public void GetAllBooks_ReturnsAllBooksSuccessfully()
        {
            // Arrange
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            List<Book> expected = this.books;
            List<Book> actual;

            // Act
            actual = this.libraryService.GetAllBooks();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method GetBookById
        /// return required book correctly.
        /// </summary>
        [TestMethod]
        public void GetBookById_ReturnsBookWithSpecifiedId()
        {
            // Arrange
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            int bookId = 1;
            Book expected = this.books[0];
            Book actual;

            // Act
            actual = this.libraryService.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBook
        /// adds book to library and returns BookId of new bool.
        /// </summary>
        [TestMethod]
        public void AddBook_ReturnsIdOfBookJustHasBeenAdded()
        {
            // Arrange
            int expected = 4;
            int actual;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Book newBook = new Book(expected, DateTime.Now, "Title4", null);

            // Act
            actual = this.libraryService.AddBook(newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBook
        /// removes book by identifier from library correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        [TestMethod]
        public void RemoveBook_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveBook(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBook
        /// removes book by identifier from library correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveBook_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveBook(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateBook
        /// updates all information about book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void UpdateBook_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Book newBook = new Book(7, DateTime.Now, "Title7", null);

            // Act
            actual = this.libraryService.UpdateBook(bookId, newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateBook
        /// updates all information about book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void UpdateBook_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Book newBook = new Book(7, DateTime.Now, "Title7", null);

            // Act
            actual = this.libraryService.UpdateBook(bookId, newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBookAutor removes
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void RemoveBookAutor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveBookAutor(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBookAutor removes
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveBookAutor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveBookAutor(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBookAutor add
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void AddBookAutor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            int authorId = 5;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.AddBookAuthor(bookId, authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBookAutor add
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void AddBookAutor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            int authorId = 5;
            this.mockDataProvider.Setup(b => b.Books).Returns(this.books);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.AddBookAuthor(bookId, authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AuthorsManagementTestMethods

        /// <summary>
        /// Checks whether method GetAllAuthors
        /// return collection of all available authors correctly.
        /// </summary>
        [TestMethod]
        public void GetAllAuthors_ReturnsAllAuthorsSuccessfully()
        {
            // Arrange
            this.mockDataProvider.Setup(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            List<Author> expected = this.authors;
            List<Author> actual;

            // Act
            actual = this.libraryService.GetAllAuthors();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method GetAuthorById
        /// return required author correctly.
        /// </summary>
        [TestMethod]
        public void GetAuthorById_ReturnsAuthorWithSpecifiedId()
        {
            // Arrange
            this.mockDataProvider.Setup(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            int authorId = 1;
            Author expected = this.authors[0];
            Author actual;

            // Act
            actual = this.libraryService.GetAuthorById(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddAuthor
        /// adds author to library and returns AuthorId of new author.
        /// </summary>
        [TestMethod]
        public void AddAuthor_ReturnsIdOfAuthorJustHasBeenAdded()
        {
            // Arrange
            int expected = 4;
            int actual;
            this.mockDataProvider.Setup(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Author newAuthor = new Author(expected, "firstname", "lastname", null);

            // Act
            actual = this.libraryService.AddAuthor(newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveAuthor
        /// removes author by identifier from library correctly
        /// in case author with such an identifier is exist.
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int authorId = 3;
            this.mockDataProvider.SetupGet(b => b.Books).Returns(this.books);
            this.mockDataProvider.SetupGet(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveAuthor
        /// removes author by identifier from library correctly
        /// in case author with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int authorId = 13;
            this.mockDataProvider.SetupProperty(a => a.Authors, this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            actual = this.libraryService.RemoveAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveAuthor
        /// removes author by identifier and
        /// all books attached to him correctly
        /// in case author with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_RemoveCascadeTheAllBooks()
        {
            // Arrange
            int authorId = 3;
            List<Book> expected = this.books;
            expected.RemoveAll(b => b.AuthorId == 3);
            List<Book> actual;
            this.mockDataProvider.SetupGet(b => b.Books).Returns(this.books);
            this.mockDataProvider.SetupGet(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);

            // Act
            this.libraryService.RemoveAuthor(authorId);
            actual = this.libraryService.GetAllBooks();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateAuthor
        /// updates all information about author
        /// with specified identifier correctly
        /// in case author with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void UpdateAuthor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int authorId = 3;
            this.mockDataProvider.Setup(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Author newAuthor = new Author(7,"firstname", "lastname", null);

            // Act
            actual = this.libraryService.UpdateAuthor(authorId, newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateAuthor
        /// updates all information about author
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void UpdateAuthor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int authorId = 13;
            this.mockDataProvider.Setup(a => a.Authors).Returns(this.authors);
            this.libraryService = new LibraryService(this.mockDataProvider.Object);
            Author newAuthor = new Author(7, "firstname", "lastname", null);

            // Act
            actual = this.libraryService.UpdateAuthor(authorId, newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
