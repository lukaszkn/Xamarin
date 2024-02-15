﻿using System;
using System.Collections.Generic;

namespace GraphQLPlayground.Models;

// https://studio.apollographql.com/public/SpaceX-pxxbxen/variant/current/explorer

public class SpaceXLaunch
{
    // {   "mission_name": "Trailblazer",   "launch_date_local": "2008-08-03T05:34:00+02:00",   "rocket": {     "rocket_name": "Falcon 1"   } }
    public string mission_name { get; set; }
}

public class SpaceXLaunchResponse
{
    public List<SpaceXLaunch> launchesPast { get; set; }
}