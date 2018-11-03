// <copyright file="ILibraryService.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Models;
    using BookLibraryBusinessLogic.Service;
    using Moq;
    using System.Diagnostics;

    /// <summary>
    /// Provides Test Methods for class LibraryService.
    /// </summary>
    [TestClass]
    public class LibratyServiceTests
    {
        /// <summary>
        /// List of default books to use
        /// mocking IDataProvider.
        /// </summary>
        private List<Book> books;
        /// <summary>
        /// List of default authors to use
        /// mocking IDataProvider.
        private List<Author> authors;

        /// <summary>
        /// LibraryService object under testing.
        /// </summary>
        private LibraryService libraryService;

        /// <summary>
        /// IDataProvider Mock.
        /// </summary>
        Mock<IDataProvider> mockDataProvider;
        
        /// <summary>
        /// Initialize required object before start of
        /// every test method.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            books = new List<Book>()
            {
                new Book(new DateTime(2017,07,07),"Title1", 3),
                new Book(new DateTime(2018,08,08),"Title2", 1),
                new Book(new DateTime(2016,06,06),"Title3", 2)
            };

            authors = new List<Author>()
            {
                new Author("FirstName1","LastName1"),
                new Author("FirstName2","LastName2", null),
                new Author("FirstName3","LastName3", "NickName"),
            };

            mockDataProvider = new Mock<IDataProvider>();

        }

        /// <summary>
        /// Checks whether method GetAllBooks
        /// return collection of all available books correctly.
        /// </summary>
        [TestMethod]
        public void GetAllBooks_ReturnsAllBooksSuccessfully()
        {
            // Arrange
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            List<Book> expected = books;
            List<Book> actual;

            // Act
            actual = libraryService.GetAllBooks();

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
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            int bookId = 1;
            Book expected = books[0];
            Book actual;

            // Act
            actual = libraryService.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual) ;
        }

        /// <summary>
        /// Checks whether method AddBook
        /// adds book to library and returns BookId of new bool.
        /// </summary>
        [TestMethod]
        public void AddBook_ReturnsIdOfBookJustHasBeenAdded()
        {
            // Arrange
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            Book newBook = new Book(DateTime.Now, "Title4", null);
            int expected = 4;
            int actual;

            // Act
            actual  = libraryService.AddBook(newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
