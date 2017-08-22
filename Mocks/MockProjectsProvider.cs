using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Models.GithubApiModels;

namespace Mocks
{
    #region Usings
    #endregion

    public class MockProjectsProvider : IProjectsProvider
    {

        public async Task<IEnumerable<Project>> Get()
        {
            return MockCardsContainer.Projects;
        }

        public Task<Project> Create(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}