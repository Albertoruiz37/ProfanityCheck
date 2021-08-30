using Assignment.ServiceLayer;
using Assignment.ServiceLayer.DataStore;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Assignment.Tests
{
    /// <summary>
    /// Testing class for the repository.
    /// </summary>
    public class RepositoryTests
    {
        /// <summary>
        /// Test add word functionality.
        /// </summary>
        [Fact]
        public void AddWordTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.AddWord(It.IsAny<Word>())).Returns(1).Verifiable("SaveChanges was not called");
            var Repository = RepositoryMock.Object;
            var word = GetMockDataSingleWord();
            Repository.AddWord(word);
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Test add words functionality.
        /// </summary>
        [Fact]
        public void AddWordsTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.AddWords(It.IsAny<List<Word>>())).Returns(1).Verifiable("SaveChanges was not called");
            var Repository = RepositoryMock.Object;
            var words = GetMockDataWordList();
            Repository.AddWords(words);
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Tests update word functionality.
        /// </summary>
        [Fact]
        public void UpdateWordTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.UpdateWord(It.IsAny<Word>())).Returns(1).Verifiable("Update was not called");
            var Repository = RepositoryMock.Object;
            var word = GetMockDataSingleWord();
            Repository.UpdateWord(word);
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Tests for delete word test.
        /// </summary>
        [Fact]
        public void DeleteWordTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.DeleteWord(It.IsAny<Word>())).Returns(1).Verifiable("Delete was not called");
            var Repository = RepositoryMock.Object;
            var word = GetMockDataSingleWord();
            Repository.DeleteWord(word);
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Tests for get word by ID.
        /// </summary>
        [Fact]
        public void GetWordByIDTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.GetWordbyId(It.IsAny<int>())).Returns(new Word()).Verifiable();
            var Repository = RepositoryMock.Object;
            var Word = Repository.GetWordbyId(1);
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Test for get word by value.
        /// </summary>
        [Fact]
        public void GetWordsByValueTest()
        {
            var RepositoryMock = new Mock<Repository>();
            RepositoryMock.Setup(x => x.GetWordbyValue(It.IsAny<string>())).Returns(new Word()).Verifiable();
            var Repository = RepositoryMock.Object;
            var Word = Repository.GetWordbyValue("dumb");
            RepositoryMock.Verify();
        }

        /// <summary>
        /// Gets a sample data word list.
        /// </summary>
        /// <returns></returns>
        private List<Word> GetMockDataWordList()
        {
            var wordList = new List<Word>()
            {
                new Word { Value = "dumb"},
                new Word { Value = "idiot"}
            };

            return wordList;
        }

        /// <summary>
        /// Gets a sample word for testing.
        /// </summary>
        /// <returns></returns>
        private Word GetMockDataSingleWord()
        {
            return new Word
            {
                Value = "dumb"
            };
        }

    }
}
