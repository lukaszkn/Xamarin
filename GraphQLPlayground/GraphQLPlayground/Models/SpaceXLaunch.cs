using System;
using System.Collections.Generic;
using GraphQL;

namespace GraphQLPlayground.Models;

// https://studio.apollographql.com/public/SpaceX-pxxbxen/variant/current/explorer

public class SpaceXLaunch
{
    // {   "mission_name": "Trailblazer",   "launch_date_local": "2008-08-03T05:34:00+02:00",   "rocket": {     "rocket_name": "Falcon 1"   } }
    public string mission_name { get; set; }
    public DateTime launch_date_local { get; set; }
    public SpaceXRocket rocket { get; set; }
}

public class SpaceXRocket
{
    public string rocket_name { get; set; }
}

public class SpaceXLaunchResponse
{
    public List<SpaceXLaunch> launchesPast { get; set; }
}