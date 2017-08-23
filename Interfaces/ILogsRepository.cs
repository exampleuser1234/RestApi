namespace Interfaces
{
    #region Using statements
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.LogsModels;

    #endregion

    public interface ILogsRepository
    {
        #region Interface methods
        Task<IEnumerable<Log>> Get();
        Task<Log> Get(string id);
        Task<Log> Insert(Log log);
        #endregion
    }
}
