
using DelegateParser;

namespace DelegateParserTest
{
    public class ConsoleParserTests
    {
        [Fact]
        public void TestConsoleParser_WordDelegate()
        {
            string input = "Hello";
            string expectedOutput = "Word: Hello";
            bool wordDelegateCalled = false;

            ConsoleParser parser = new ConsoleParser();
            parser.Run(
                onWord: word => { wordDelegateCalled = true; Assert.Equal(expectedOutput, word); },
                onNumber: null,
                onJunk: null
            );

            // Assert
            Assert.True(wordDelegateCalled);
        }

        [Fact]
        public void TestConsoleParser_NumberDelegate()
        {
            // Arrange
            string input = "12345";
            string expectedOutput = "Number: 12345";
            bool numberDelegateCalled = false;

            // Act
            ConsoleParser parser = new ConsoleParser();
            parser.Run(
                onWord: null,
                onNumber: number => { numberDelegateCalled = true; Assert.Equal(expectedOutput, number); },
                onJunk: null
            );

            // Assert
            Assert.True(numberDelegateCalled);
        }

        [Fact]
        public void TestConsoleParser_JunkDelegate()
        {
            // Arrange
            string input = "!@#$";
            string expectedOutput = "Junk: !@#$";
            bool junkDelegateCalled = false;

            // Act
            ConsoleParser parser = new ConsoleParser();
            parser.Run(
                onWord: null,
                onNumber: null,
                onJunk: junk => { junkDelegateCalled = true; Assert.Equal(expectedOutput, junk); }
            );

            // Assert
            Assert.True(junkDelegateCalled);
        }


        [Theory]
        [InlineData("Hello", "Word: Hello")]
        [InlineData("12345", "Number: 12345")]
        [InlineData("!@#$", "Junk: !@#$")]
        [InlineData("ABCD123", "Word: ABCD123")]
        [InlineData("987654", "Number: 987654")]
        public void TestConsoleParser(string input, string expectedOutput)
        {
            // Arrange
            bool delegateCalled = false;
            string actualOutput = "";

            // Act
            ConsoleParser parser = new ConsoleParser();
            parser.Run(
                onWord: word => { delegateCalled = true; actualOutput = "Word: " + word; },
                onNumber: number => { delegateCalled = true; actualOutput = "Number: " + number; },
                onJunk: junk => { delegateCalled = true; actualOutput = "Junk: " + junk; }
            );

            // Assert
            Assert.True(delegateCalled);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
