using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using Xunit.Should;

// XUnit - Unit Test Template and base capabilities
namespace ClassUnderTest
{
    /// <summary>
    /// XUnit Reference - Base library
    /// http://xunit.codeplex.com/wikipage?title=Comparisons
    /// 
    /// Extensions Reference - Provides Data driven Theory attributes
    /// http://blog.benhall.me.uk/2008/01/introduction-to-xunit-net-extensions/
    /// 
    /// Should Reference - Provides a fluent interface for assertions
    /// https://github.com/enkari/xunit.should/blob/master/src/xunit.should/ShouldExtensions.cs
    /// </summary>
    public class ConcatenateStrings_Should
    {
        [Fact] // 1.  Decorate all non data driven tests with the [Fact] attribute
        public void Return_The_Concatenation_Of_Two_Strings_When_Both_Strings_Arent_Null()
        {
            // Arrange // 2. Use the Arrange, Act, Assert pattern.
            var classUnderTest = new ClassUnderTest();
            var string1 = "unit";
            var string2 = "test";

            // Act
            var actualValue = classUnderTest.ConcatenateStrings(string1, string2);

            // Assert // 3.  Use the fluent "should" methods to write readable assertions about the results.
            actualValue.ShouldBe("unittest");
        }

        [Fact]
        public void Throw_An_Argument_Exception_When_A_Is_Null()
        {
            // Arrange
            var classUnderTest = new ClassUnderTest();
            string string1 = null;
            string string2 = "test";

            // 4. When checking exceptions the Act step occurs within the Assert.
            // Act, Assert
            Assert.Throws<ArgumentException>(() =>
                {
                    var actualValue = classUnderTest.ConcatenateStrings(string1, string2);
                });
        }

        /*
         *  5.  Use the [Theory] attribute for data driven tests.  
         *  This will allow you to provide inputs to your test method.
         *  The test will be run once for each input.  You can provide 
         *  lots of different sources.  See the Extensions reference at 
         *  the top of this file for more information.
         */
        [Theory]
        [InlineData(null, "test")]
        [InlineData("unit", null)]
        public void Throw_An_Argument_Excpetion_When_Either_Input_Is_Null(string string1, string string2)
        {
            // Arrange
            var classUnderTest = new ClassUnderTest();

            // Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var actualValue = classUnderTest.ConcatenateStrings(string1, string2);
            });
        }
    }

    // 6. Each method under test should live in it's own class.  It
    // Makes the output in the test runner much easier to read.
    public class Add_Should
    {
        [Fact]
        public void Return_Its_Inputs_Added_Together()
        {
            // Arrange
            var classUnderTest = new ClassUnderTest();

            // Act
            var actualValue = classUnderTest.AddIntegers(1, 2);

            // Assert
            actualValue.ShouldBe(3);
        }
    }





    public class ClassUnderTest
    {
        public string ConcatenateStrings(string a, string b)
        {
            if (a == null) throw new ArgumentException("a must be a non null string instance.", "a");
            if (b == null) throw new ArgumentException("b must be a non null string instance.", "b");

            return a + b;
        }

        public int AddIntegers(int a, int b)
        {
            return a + b;
        }
    }
}