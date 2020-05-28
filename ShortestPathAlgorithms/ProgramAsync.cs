using AlgorithmLibrary.Algorithms;
using AlgorithmLibrary.Helpers;

using Microsoft.Extensions.DependencyInjection;

using ShortestPathAlgorithms.Algorithms;

using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms
{
    public class ProgramAsync
    {
        public async Task MainAsync()
        {
            try
            {
                //TODO: implement a picker based on the input.
                var services = BuildServiceProvider();
                await services.GetRequiredService<IDijkstraAlgorithm>().GetAsync(new Vector2(0, 0), new Vector2(2, 2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private IServiceProvider BuildServiceProvider()
            => new ServiceCollection()
            .AddSingleton<ICreateGraphHelper, CreateGraphHelper>()
            .AddSingleton<IGetAllNodesHelper, GetAllNodesHelper>()
            .AddSingleton<ISortNodesByDistanceHelper, SortNodesByDistanceHelper>()
            .AddSingleton<IGetNeighborsHelper, GetNeighborsHelper>()
            .AddSingleton<IUpdateUnvisitedNodesHelper, UpdateUnvisitedNodesHelper>()
            .AddSingleton<IDijkstraAlgorithm, DijkstraAlgorithm>()
            .AddSingleton<IAStarSearchAlgorithm, AStarSearchAlgorithm>()
            .BuildServiceProvider();
    }
}
