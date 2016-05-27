using FluentTextGeneratorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FluentTextGeneratorLibraryTests
{
    [TestClass]
    public class FluentTextGeneratorLibraryTest
    {
        private FluentTextGenerator generator = null;

        private int minLength = 0;
        private int maxLength = 0;
        private bool small = false;
        private bool capital = false;
        private bool special = false;
        private bool numbers = false;
        private string excludeList = String.Empty;

        private string generateRegardingConfiguration()
        {
            return 
            generator.Configure()
                .MinLength(minLength)
                .MaxLength(maxLength)
                .IncludeCapitalCharacters(capital)
                .IncludeSmallCharacters(small)
                .IncludeNumbers(numbers)
                .IncludeSpecialCharacters(special)
                .ExcludeCharacters(excludeList)
                .Generate();
        }

        [TestInitialize]
        public void InitTest()
        {
            // reset configuration
            minLength = 0;
            maxLength = 0;
            small = false;
            capital = false;
            special = false;
            numbers = false;
            excludeList = String.Empty;
            //
            generator = new FluentTextGenerator();
        }

        [TestMethod]
        public void EmptyAlphabetTest()
        {
            // arrange
            Exception emptyAlphabetException = null;
            // act
            try
            {
                generateRegardingConfiguration();
            }
            catch (Exception exception)
            {
                emptyAlphabetException = exception;
            }
            // assert
            Assert.IsNotNull(emptyAlphabetException);
            Assert.IsInstanceOfType(emptyAlphabetException, typeof(Exception));
            Assert.AreEqual(emptyAlphabetException.Message, @"At least one character configuration should be true in order to create an alphabet!");
        }

        [TestMethod]
        public void MinLengthTest()
        {
            // arrange
            const int expectedMinLength = 5;
            // act
            small = true;
            minLength = 5;
            var text = generateRegardingConfiguration();
            // assert
            Assert.IsFalse(String.IsNullOrEmpty(text));
            Assert.IsTrue(text.Length >= expectedMinLength);
        }

        [TestMethod]
        public void MaxLengthTest()
        {
            // arrange
            const int expectedMaxLength = 5;
            // act
            small = true;
            maxLength = 5;
            var text = generateRegardingConfiguration();
            // assert
            Assert.IsFalse(String.IsNullOrEmpty(text));
            Assert.IsTrue(text.Length <= expectedMaxLength);
        }

        [TestMethod]
        public void MinMaxSameLengthTest()
        {
            // arrange
            const int expectedLength = 5;
            // act
            small = true;
            minLength = 5;
            maxLength = 5;
            var text = generateRegardingConfiguration();
            // assert
            Assert.IsFalse(String.IsNullOrEmpty(text));
            Assert.IsTrue(text.Length == expectedLength);
        }

        [TestMethod]
        public void SmallCharactersTest()
        {
            // arrange
            const bool expectedResult = true;
            // act
            small = true;
            var text = generateRegardingConfiguration();
            var actualResult = !text.ToCharArray().Any(ch => !char.IsLower(ch));
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CapitalCharactersTest()
        {
            // arrange
            const bool expectedResult = true;
            // act
            capital = true;
            var text = generateRegardingConfiguration();
            var actualResult = !text.ToCharArray().Any(ch => !char.IsUpper(ch));
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OnlyNumbersTest()
        {
            // arrange
            const bool expectedResult = true;
            // act
            numbers = true;
            var text = generateRegardingConfiguration();
            var actualResult = System.Text.RegularExpressions.Regex.IsMatch(text, @"\d");
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //[TestMethod]
        //public void Test()
        //{
        //    // arrange
        //    // act
        //    // assert
        //    Assert.Inconclusive();
        //}
    }
}
