namespace Mocks
{
    #region Usings
    using System.Collections.Generic;
    using Models;
    using Models.GithubApiModels;
    #endregion

    public static class MockCardsContainer
    {
        #region Coonstructor
        static MockCardsContainer()
        {
            Init();
        }
        #endregion

        #region Methods
        public static void Init()
        {
            Projects = new List<Project>()
            {
                new Project()
                {
                    id=10,
                    name="Test"
                }
            };
            CardId = 100;
            Columns = new List<Column>()
            {
                new Column()
                {
                    id=0,
                    name="Backlog"
                },
                new Column()
                {
                    id=1,
                    name="To Do"
                },
                new Column()
                {
                    id=2,
                    name="In Progress"
                },
                new Column()
                {
                    id=3,
                    name="Done"
                }
            };
            Cards = new List<List<Card>>()
            {

                new List<Card>(),
                new List<Card>(),
                new List<Card>(),
                new List<Card>()
            };
        }
        #endregion

        #region Fields
        public static int CardId;
        public static List<Project> Projects;
        public static List<Column> Columns;
        public static List<List<Card>> Cards;
        #endregion
    }
}
