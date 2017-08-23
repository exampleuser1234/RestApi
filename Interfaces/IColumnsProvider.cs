namespace Interfaces
{
    #region Using statements
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.GithubApiModels;

    #endregion

    public interface IColumnsProvider
    {
        #region Interface methods
        Task<IEnumerable<Column>> Get(string projectId);
        Task<Column> Create(string projectId, string columnName);
        #endregion
    }
}
