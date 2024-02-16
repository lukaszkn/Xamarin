using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQLPlayground.Models;

// https://www.apollographql.com/blog/8-free-to-use-graphql-apis-for-your-projects-and-demos
// https://studio.apollographql.com/public/SpaceX-pxxbxen/variant/current/explorer


namespace GraphQLPlayground.Services
{
    public class SpaceXService : ISpaceXService
    {

        public async Task<List<SpaceXLaunch>> GetSpaceXLaunchesAsync()
        {
            var graphQLHttpClientOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://spacex-production.up.railway.app/")
            };

            var httpClient = new HttpClient();
            var graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions, new GraphQL.Client.Serializer.Newtonsoft.NewtonsoftJsonSerializer(), httpClient);

            var launchesRequest = new GraphQLRequest
            {
                Query = @"
                    {
                        launchesPast(limit: 40) {
                            mission_name
                            launch_date_local
                            rocket {
                              rocket_name
                            }
                          }
                    }
                "
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<SpaceXLaunchResponse>(launchesRequest);
            return graphQLResponse.Data.launchesPast;
        }
    }
}

