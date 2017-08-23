namespace Mocks
{
    #region Using statements
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.GithubApiModels;
    #endregion

    public class MockColumnsProvider : IColumnsProvider
    {
        #region Implementation of IColumnsProvider
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
            return project == 10 ? MockCardsContainer.Columns : null;
        }

        public Task<Column> Create(string projectId, string columnName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
