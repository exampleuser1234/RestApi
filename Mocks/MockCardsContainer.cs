using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Models.GithubApiModels;

namespace Mocks
{
    public static class MockCardsContainer
    {
        static MockCardsContainer()
        {
            Init();
        }

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

        public static int CardId;
        public static List<Project> Projects;
        public static List<Column> Columns;
        public static List<List<Card>> Cards;
    }
}
