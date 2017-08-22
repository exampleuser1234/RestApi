﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.GithubApiModels;

namespace Interfaces
{
    public interface IProjectsProvider
    {
        Task<IEnumerable<Project>> Get();
        Task<Project> Create(string name);
    }
}