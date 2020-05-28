﻿using AlgorithmLibrary.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmLibrary.Helpers
{
    public interface IUpdateUnvisitedNodesHelper
    {
        Task UpdateAsync(IBasicNodeModel node, List<List<IBasicNodeModel>> graph);
    }
}