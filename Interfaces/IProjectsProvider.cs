namespace Interfaces
{
    #region Using statements
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.GithubApiModels;

    #endregion

    public interface IProjectsProvider
    {
        #region Interface  methods
        Task<IEnumerable<Project>> Get();
        Task<Project> Create(string name);
        #endregion
    }
}
