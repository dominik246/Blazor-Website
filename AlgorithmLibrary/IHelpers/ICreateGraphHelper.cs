using AlgorithmLibrary.IModels;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLibrary.IHelpers
{
    public interface ICreateGraphHelper
    {
        Task<List<List<IBasicNodeModel>>> GetAsync(int width, int height);
    }
}
