using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLPlayground.Models;

namespace GraphQLPlayground.Services;

public interface ISpaceXService
{
    Task<List<SpaceXLaunch>> GetSpaceXLaunchesAsync();
}

