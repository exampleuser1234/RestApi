namespace Mocks
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.GithubApiModels;
    #endregion

    public class MockColumnsProvider : IColumnsProvider
    {
        public async Task<IEnumerable<Column>> Get(string projectId)
        {
            int project;
            try
            {
                project = int.Parse(projectId);
            }
            catch
            {
                return null;
            }
            if (project == 10)
            {
                return MockCardsContainer.Columns;
            }
            else
            {
                return null;
            }
        }

        public Task<Column> Create(string projectId, string columnName)
        {
            throw new NotImplementedException();
        }
    }
}
