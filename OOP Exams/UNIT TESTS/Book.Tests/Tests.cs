namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CtorShouldCreateCorrectObject()
        {
            Book book = new Book("BookName", "BookAuthor");

            Assert.AreEqual("BookName",book.BookName);
            Assert.AreEqual("BookAuthor", book.Author);
            
        }

        [Test]
        public void FoodnoteCounterShouldReturnCorrectValue()
        {
            Book book = new Book("BookName", "BookAuthor");
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void NullOrEmptyBookNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(string.Empty, "BookAuthor");
            },"Invalid BookName");

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "BookAuthor");
            }, "Invalid BookName");
        }

        [Test]
        public void BookNameShouldReturnProperValue()
        {
            Book book = new Book("BookName", "BookAuthor");

            Assert.That(book.BookName, Is.EqualTo("BookName"));
        }

        [Test]
        public void NullOrEmptyAuthorShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("BookName", string.Empty);
            }, "Invalid Author");

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("BookName", null);
            }, "Invalid Author");
        }

        [Test]
        public void AuthorShouldReturnProperValue()
        {
            Book book = new Book("BookName", "BookAuthor");

            Assert.That(book.Author, Is.EqualTo("BookAuthor"));
        }

        [Test]
        public void AddingAlreadyExistsFootnoteShouldThrowException()
        {
            Book book = new Book("BookName", "BookAuthor");
            book.AddFootnote(4, "Text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(4, "Text");
            }, "Footnote already exists!");
        }

        [Test]
        public void AddFootnoteShouldWorksCorrect()
        {
            Book book = new Book("BookName", "BookAuthor");
            book.AddFootnote(4, "Text");

            Assert.AreEqual("Footnote #4: Text", book.FindFootnote(4));
        }

        [Test]
        public void FindFootnoteShouldThrowExceptionIfKeyDoesnotExists()
        {
            Book book = new Book("BookName", "BookAuthor");
            book.AddFootnote(4, "Text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(5);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootnoteShouldThrowExceptionIfKeyDoesnotExists()
        {
            Book book = new Book("BookName", "BookAuthor");
            book.AddFootnote(4, "Text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(5,"newText");
            }, "Footnote does not exists!");
        }
        [Test]
        public void AlterFootnoteShouldWorksCorrect()
        {
            Book book = new Book("BookName", "BookAuthor");
            book.AddFootnote(4, "Text");
            book.AlterFootnote(4, "NewText");

            Assert.AreEqual("Footnote #4: NewText", book.FindFootnote(4));
        }
    }
}