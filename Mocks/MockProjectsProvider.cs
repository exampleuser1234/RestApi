namespace Mocks
{
    #region Using statements
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.GithubApiModels;
    #endregion

    public class MockProjectsProvider : IProjectsProvider
    {
        #region Implementation of IProjectsProvider
        public async Task<IEnumerable<Project>> Get()
        {
            return MockCardsContainer.Projects;
        }

        public Task<Project> Create(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}