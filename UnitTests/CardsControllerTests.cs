namespace UnitTests
{
    #region Using statements
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GithubServices;
    using Models.GithubApiModels;
    using DeluxeRestApp.Controllers;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Mocks;
    using Models.LogsModels;
    using Models.RestApiModels;
    using Moq;
    using Xunit;
    #endregion

    public class CardsControllerTests
    {
        #region Constructor
        public CardsControllerTests()
        {
            Environment.Init(new MockProjectsProvider(), new MockColumnsProvider()).Wait();
            MockCardsContainer.Init();

            var mockLogsRepository = new Mock<ILogsRepository>();
            mockLogsRepository.Setup(x => x.Insert(It.IsAny<Log>())).Returns((Log a) => Task.FromResult(a));
            _controller = new CardsController(new MockCardsProvider(), new MockColumnsProvider(),
                mockLogsRepository.Object);
        }
        #endregion

        #region Private fields
        private readonly CardsController _controller;
        #endregion

        #region Properties for theories
        public static IEnumerable<object[]> NoteCombinations
        {
            get
            {
                var s1 = new[] {"{0}", "{0} na poczt¹ku", "W œrodku{0}something", "na koñcu{0}"};
                var s2 = new[] {"tekst", "tekst ze spacj¹", " tekst "};
                var s3 = new[] {"inny_tekst", "inny tekst", string.Empty};
                var product =
                    from first in s1
                    from second in s2
                    from third in s3
                    select new[] {(object) first, second, third, string.Format(first, third)};
                return product;
            }
        }

        public static IEnumerable<object[]> WrongIds => new List<object[]>
        {
            new[] {(object) "wrong"},
            new[] {(object) "very wrong"},
            new[] {(object) "1234555678"},
            new[] {(object) "-12"}
        };
        #endregion

        #region Replace tests
        [Theory]
        [MemberData(nameof(NoteCombinations))]
        public void ReplaceTest_VariousPatterns(string note, string pattern, string change, string newNote)
        {
            const int expectedCode = 200;
            const int columnNumber = 0;

            note = string.Format(note, pattern);
            var card = this.SetUpCard(note, columnNumber);

            var result = _controller.Replace(new ReplaceModel
            {
                column = columnNumber.ToString(),
                pattern = pattern,
                change_to = change
            }).Result;

            this.CheckIActionResult(result, expectedCode);
            Assert.Equal(newNote, card.note);
        }

        [Theory]
        [InlineData("Backlog", 0)]
        [InlineData("0", 0)]
        [InlineData("To Do", 1)]
        [InlineData("To Do", 3)]
        public void ReplaceTest_VariusColumnNames(string columnName, int columnNumber)
        {
            const string note = "something test";
            const string pattern = "test";
            const string change = "new";
            const string newNote = "something new";
            const int expectedCode = 200;

            var card = this.SetUpCard(note, columnNumber);

            var result = _controller.Replace(new ReplaceModel
            {
                column = columnName,
                pattern = pattern,
                change_to = change
            }).Result;

            this.CheckIActionResult(result, expectedCode);
            Assert.Equal(newNote, card.note);
        }

        [Theory]
        [MemberData(nameof(WrongIds))]
        public void ReplaceTest_WrongColumnId_UnprocessableEntityStatusCode(string columnId)
        {
            const int expectedCode = 422;
            var result = _controller.Replace(new ReplaceModel
            {
                column = columnId,
                pattern = string.Empty,
                change_to = string.Empty
            }).Result;
            this.CheckIActionResult(result, expectedCode);
        }

        [Fact]
        public void ReplaceTest_NoneWithThatPattern_NotFoundStatusCode()
        {
            const int columnNumber = 0;
            const int expectedCode = 404;
            const string note = "something";
            const string pattern = "test";

            this.SetUpCard(note, columnNumber);

            var result = _controller.Replace(new ReplaceModel
            {
                column = columnNumber.ToString(),
                pattern = pattern,
                change_to = string.Empty
            }).Result;

            this.CheckIActionResult(result, expectedCode);
        }
        #endregion

        #region Move tests
        [Theory]
        [MemberData(nameof(WrongIds))]
        public void MoveTest_WrongColumnId_UnprocessableEntityStatusCode(string columnId)
        {
            const int expectedCode = 422;
            var result = _controller.Move(new MoveModel
            {
                column_from = columnId,
                pattern = string.Empty,
                column_to = "2"
            }).Result;
            this.CheckIActionResult(result, expectedCode);
        }

        [Fact]
        public void MoveTest_NoneWithThatPattern_NotFoundStatusCode()
        {
            const int expectedCode = 404;
            const int columnFrom = 0;
            const int columnTo = 1;
            const string note = "something";
            const string pattern = "test";

            this.SetUpCard(note, columnFrom);

            var result = _controller.Move(new MoveModel
            {
                column_from = columnFrom.ToString(),
                pattern = pattern,
                column_to = columnTo.ToString()
            }).Result;

            this.CheckIActionResult(result, expectedCode);
        }
        #endregion

        #region Delete tests
        [Theory]
        [MemberData(nameof(WrongIds))]
        public void DeleteTest_WrongColumnId_UnprocessableEntityStatusCode(string columnId)
        {
            const int expectedCode = 422;
            var result = _controller.Delete(new DeleteModel
            {
                column = columnId,
                pattern = string.Empty
            }).Result;
            this.CheckIActionResult(result, expectedCode);
        }

        [Fact]
        public void DeleteTest_NoneWithThatPattern_NotFoundStatusCode()
        {
            const int expectedCode = 404;
            const int columnNumber = 0;
            const string note = "something";
            const string pattern = "test";

            this.SetUpCard(note, columnNumber);

            var result = _controller.Delete(new DeleteModel
            {
                column = columnNumber.ToString(),
                pattern = pattern
            }).Result;

            this.CheckIActionResult(result, expectedCode);
        }

        #endregion

        #region Import tests
        [Theory]
        [MemberData(nameof(WrongIds))]
        public void ImportTest_NoneWithThatPattern_NotFoundStatusCode(string projectId)
        {
            const int expectedCode = 404;
            var result = _controller.Import(projectId).Result;
            this.CheckIActionResult(result, expectedCode);
        }

        #endregion

        #region Private methods
        private void CheckIActionResult(IActionResult result, int code)
        {
            Assert.IsType(typeof(StatusCodeResult), result);
            Assert.NotNull(result);
            Assert.Equal(code, (result as StatusCodeResult).StatusCode);
        }

        private Card SetUpCard(string note, int columnNumber)
        {
            var card = new Card
            {
                note = note
            };
            MockCardsContainer.Cards[columnNumber].Add(card);
            return card;
        }
        #endregion
    }
}