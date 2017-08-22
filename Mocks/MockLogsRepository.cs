//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Interfaces;
//using Models.LogsModels;
//using MongoDB.Bson;

//namespace Mocks
//{
//    public class MockLogsRepository : ILogsRepository
//    {
//        private static List<Log> _logs = new List<Log>();
//        public async Task<IEnumerable<Log>> Get()
//        {
//            return _logs;
//        }

//        public async Task<Log> Get(string id)
//        {
//            return _logs.FirstOrDefault(l => l.Id.ToString().Equals(id));
//        }

//        public async Task<Log> Insert(Log log)
//        {
//            log.Id=new ObjectId();
//            _logs.Add(log);
//            return log;
//        }
//    }
//}
