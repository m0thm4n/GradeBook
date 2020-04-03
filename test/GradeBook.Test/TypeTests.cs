using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate logDelegate = ReturnMessage;

            logDelegate += ReturnMessage;

            var result = logDelegate("Hello!");

            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void Test1()
        {
            int x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            
            
            // act
            


            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;

            
            
            // act
            


            // assert
            Assert.Same(book1, book2);
        }

        InMemoryBook GetBook(string name) 
        {
            return new InMemoryBook(name);
        }
    }
}
