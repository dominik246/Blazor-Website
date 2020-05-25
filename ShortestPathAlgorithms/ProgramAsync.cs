using Microsoft.Extensions.DependencyInjection;

using ShortestPathAlgorithms.Algorithms;
using ShortestPathAlgorithms.Helpers;

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
                var services = BuildServiceProvider();
                await services.GetRequiredService<DijkstraAlgorithm>().Get(new Vector2(0, 0), new Vector2(2, 2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private IServiceProvider BuildServiceProvider()
            => new ServiceCollection()
            .AddSingleton<CreateGraphHelper>()
            .AddSingleton<GetAllNodesHelper>()
            .AddSingleton<SortNodesByDistanceHelper>()
            .AddSingleton<GetNeighborsHelper>()
            .AddSingleton<UpdateUnvisitedNodesHelper>()
            .AddSingleton<DijkstraAlgorithm>()
            .BuildServiceProvider();
    }
}
