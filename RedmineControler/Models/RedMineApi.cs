using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Utf8Json;

namespace RedmineControler
{
    static class RedMineApi
    {
        public static async Task<GetIssueData> GetIssueAsync( string url, string apiKey )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/issues.json?key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<GetIssueData>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }

        public static async Task<GetIssueData> GetIssueAsync( string url, string apiKey, int projectId )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/issues.json?project_id={projectId}&key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<GetIssueData>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PostIssueAsync( string url, string apiKey, PostIssueData issue )
        {
            try {
                var content = new ByteArrayContent( JsonSerializer.Serialize( issue ) );
                var apiResponce = await new HttpClient().PostAsync( $"{url}/issues.json?key={apiKey}", content )
                                                        .ConfigureAwait( false );

                return apiResponce;
            }
            catch( Exception ) {
                throw;
            }
        }

        public static async Task<Projects> GetProjectAsync( string url, string apiKey )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/projects.json?key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<Projects>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }
    }
}
