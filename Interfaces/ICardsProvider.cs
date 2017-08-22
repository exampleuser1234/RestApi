

namespace Interfaces
{
    #region Usings
    using System.Collections.Generic;
    using Models.GithubApiModels;
    using System.Threading.Tasks;
    using Models;
    #endregion

    public interface ICardsProvider
    {
        Task<IEnumerable<Card>> Get(string columnId);
        Task<IEnumerable<Card>> Get(string columnId, string pattern);
        Task<bool> Move(string id, string columnId);
        Task<Card> Edit(string id, string note);
        Task<bool> Delete(string id);
        Task<Card> Create(string columnId, string note);
    }
}
