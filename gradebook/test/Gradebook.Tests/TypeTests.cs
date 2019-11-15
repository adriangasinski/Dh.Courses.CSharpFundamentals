using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("book 1");
            var book2 = GetBook("book 2");

            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);
            
        }

        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var book1 = GetBook("book 1");
            var book2 = book1;

            SetName(book2, "book 2");

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            Assert.Equal("book 2", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");
            
            Assert.Same(book1.Name, "New name");
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

         [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");
            
            Assert.Same(book1.Name, "Book 1");
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharCansPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New name");
            
            Assert.Same(book1.Name, "New name");
        }

        private void GetBookSetNameRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
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

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            string name = "Scott";

            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
    }
}
