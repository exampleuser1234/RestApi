using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Mocks
{
    public class MockColumnsProvider : IColumnsProvider
    {
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
            if (project == 10)
            {
                return MockCardsContainer.Columns;
            }
            else
            {
                return null;
            }
        }

        public Task<Column> Create(string projectId, string columnName)
        {
            throw new NotImplementedException();
        }
    }
}
