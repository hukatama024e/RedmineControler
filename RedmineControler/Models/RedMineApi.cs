﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
                var content = new StringContent( Encoding.UTF8.GetString( JsonSerializer.Serialize( issue ) ),
                                                    Encoding.UTF8, "application/json" );

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

        public static async Task<Trackers> GetTrackerAsync( string url, string apiKey )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/trackers.json?key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<Trackers>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }

        public static async Task<IssueStatuses> GetIssueStatusAsync( string url, string apiKey )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/issue_statuses.json?key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<IssueStatuses>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }

        public static async Task<IssuePriorities> GetIssuePriorityAsync( string url, string apiKey )
        {
            try {
                var apiResponce = await new HttpClient().GetStringAsync( $"{url}/enumerations/issue_priorities.json?key={apiKey}" )
                                                        .ConfigureAwait( false );

                return JsonSerializer.Deserialize<IssuePriorities>( apiResponce );
            }
            catch( Exception ) {
                throw;
            }
        }
    }
}
