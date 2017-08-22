using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.LogsModels;

namespace Interfaces
{
    public interface ILogsRepository
    {
        Task<IEnumerable<Log>> Get();
        Task<Log> Get(string id);
        Task<Log> Insert(Log log);
    }
}
