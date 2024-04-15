

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void TestName()
        {
            // Given
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            // When
            var result = log("Hello!");
        
            // Then
            Assert.Equal("Hello!", result);
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // Arrange
            var name = "Mathews";

            // Act
            var upper = MakeUpper(name);
        
            // Assert
            Assert.Equal("MATHEWS", upper);
            Assert.Equal("Mathews", name);
        }

        private string MakeUpper(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            // Arrange
        
            // Act
            var x = GetInt();
            SetInt(x);
        
            // Assert
            Assert.Equal(3, x);
        }

        private void SetInt(int x)
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
            // Arrange
            var bookName = "Book 1";
            var newBookName = "New Name";
        
            // Act
            var book = GetBook(bookName);
            GetBookSetName(ref book, newBookName);
        
            // Assert
            Assert.Equal(newBookName, book.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var bookName = "Book 1";
            var newBookName = "New Name";
        
            // Act
            var book = GetBook(bookName);
            GetBookSetName(book, newBookName);
        
            // Assert
            Assert.Equal(bookName, book.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var bookName = "Book 1";
            var newBookName = "New Name";
        
            // Act
            var book = GetBook(bookName);
            SetName(book, newBookName);
        
            // Assert
            Assert.Equal(newBookName, book.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange
            var book1Name = "Book 1";
            var book2Name = "Book 2";
        
            // Act
            var book1 = GetBook(book1Name);
            var book2 = GetBook(book2Name);
        
            // Assert
            Assert.Equal(book1Name, book1.Name);
            Assert.Equal(book2Name, book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange
            var book1Name = "Book 1";
        
            // Act
            var book1 = GetBook(book1Name);
            var book2 = book1;
        
            // Assert
            Assert.Same(book1, book2);
            Assert.True(ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}