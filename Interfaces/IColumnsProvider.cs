using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.GithubApiModels;

namespace Interfaces
{
    #region Usings
    #endregion

    public interface IColumnsProvider
    {
        Task<IEnumerable<Column>> Get(string projectId);
        Task<Column> Create(string projectId, string columnName);
    }
}
