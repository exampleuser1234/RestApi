namespace GithubServices
{
    #region Using statements
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using System;
    using Models;
    using Models.GithubApiModels;
    #endregion

    public static class Environment
    {
        #region Public fields
        public static string AuthToken="<OAUTHTOKEN>";
        public static string ProjectId;
        public static Dictionary<string, string> ColumnNamesIds;
        #endregion

        #region Private fileds
        private static readonly List<string> ColumnNames = new List<string>()
        {
            "Backlog",
            "To Do",
            "In Progress",
            "Done"
        };
        #endregion

        #region Methods
        public static async Task<bool> Init(IProjectsProvider projectsProvider,IColumnsProvider columnsProvider)
        {
            ColumnNamesIds = new Dictionary<string, string>();
            var projects = await projectsProvider.Get();
            if (projects == null)
                return false;
            Project project;
            if ((project = projects.FirstOrDefault(p => p.name.Equals(Constants.ProjectName)))==null)
            {
                project = await projectsProvider.Create(Constants.ProjectName);
                if (project == null)
                    return false;
            }
            ProjectId = project.id.ToString();
            var columns = (await columnsProvider.Get(ProjectId)).ToList();
            if (columns == null)
                return false;
            foreach (var columnName in ColumnNames)
            {
                Column column;
                if ((column = columns.FirstOrDefault(c => c.name.Equals(columnName)))==null)
                {
                    column = await columnsProvider.Create(ProjectId, columnName);
                    if ( column == null)
                        return false;
                }
                ColumnNamesIds.Add(columnName, column.id.ToString());
            }
            Console.WriteLine("Initialization finished successfully.");
            return true;
        }
        #endregion
    }
}
