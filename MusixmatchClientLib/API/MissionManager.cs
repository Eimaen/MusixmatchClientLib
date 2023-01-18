using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using MusixmatchClientLib.API.Contexts;
using MusixmatchClientLib.API.Model.Requests;
using MusixmatchClientLib.API.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusixmatchClientLib.API
{
    // [ Circus-P - Last of Me ] You can keep the last of me, I don't care, I am obsolete 🎵
    [Obsolete("This method is not well tested & GraphQL API of Musixmatch's missions is not fully reverse-engineered. Use at your own risk.")]
    public class MissionManager
    {
        private string jwtToken { get; set; }
        private string userId { get; set; }
        private ApiRequestFactory requestFactory { get; set; }
        private GraphQLHttpClient graphQLClient { get; set; }

        internal MissionManager(ApiRequestFactory reqFactory)
        {
            if (MusixmatchApiContext.Recover(reqFactory.Context) != ApiContext.Community)
                throw new Exception("Only community tokens work with Missions API.");

            requestFactory = reqFactory;
            jwtToken = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.RequestJwtToken).Cast<JwtGet>().JwtToken;
            userId = requestFactory.SendRequest(ApiRequestFactory.ApiMethod.UserGet).Cast<UserGet>().UserData.UserId;
            graphQLClient = new GraphQLHttpClient("https://missions-backend-new.musixmatch.com/graphql", new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(jwtToken);
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Origin", "https://curators.musixmatch.com");
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:101.0) Gecko/20100101 Firefox/101.0");
        }

        public List<Mission> GetMissions() => GetMissionsAsync().GetAwaiter().GetResult();

        public async Task<List<Mission>> GetMissionsAsync()
        {
            var missionListRequest = new GraphQLRequest
            {
                Query = @"
                query AvailableMissionsList($appId: String, $userId: ID, $userToken: String) {  
                    getAvailableMissions(input: {appId: $appId, userId: $userId, userToken: $userToken}) {    
                        items {
                            id
                            description
                            title
                        }
                    }
                }",
                OperationName = "AvailableMissionsList",
                Variables = new
                {
                    appId = requestFactory.Context.AppId,
                    userId = userId,
                    userToken = requestFactory.UserToken
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync(missionListRequest, () => new { getAvailableMissions = new GraphQLAvailableMissionsListResponse() });
            return graphQLResponse.Data.getAvailableMissions.Items;
        }

        public List<MissionTrack> GetMissionTracks(string missionId, string languages = "en", string destinationLanguage = "en", int limit = 25, bool sortAscending = true) => GetMissionTracksAsync(missionId, languages, destinationLanguage, limit, sortAscending).GetAwaiter().GetResult();

        public async Task<List<MissionTrack>> GetMissionTracksAsync(string missionId, string languages = "en", string destinationLanguage = "en", int limit = 25, bool sortAscending = true)
        {
            var missionListRequest = new GraphQLRequest
            {
                Query = @"
                query LyricsList(
                    $appId: String
                    $languages: String
                    $destinationLanguage: String
                    $limit: Int = 25
                    $missionId: String
                    $nextToken: String = null
                    $sortAscending: Boolean = true
                    $sortBy: String = ""rank""
                    $status: String = ""AVAILABLE""
                    $userToken: String
                ) {
                    getSortedLyrics(
                        appId: $appId
                        languages: $languages
                        destinationLanguage: $destinationLanguage
                        limit: $limit
                        missionId: $missionId
                        nextToken: $nextToken
                        sortForward: $sortAscending
                        sortBy: $sortBy
                        status: $status
                        userToken: $userToken
                    ) {
                        items {
                            id
                            artistName
                            commonTrackId
                            hasLyrics
                            hasSync
                            language
                            title
                        }
                    }
                }
                ",
                OperationName = "LyricsList",
                Variables = new
                {
                    appId = requestFactory.Context.AppId,
                    destinationLanguage = destinationLanguage,
                    languages = languages,
                    limit = limit,
                    missionId = missionId.Replace("MISSION.", string.Empty),
                    sortAscending = $"{sortAscending}",
                    sortBy = "language",
                    status = "AVAILABLE",
                    userToken = requestFactory.UserToken
                }   
            };
            var graphQLResponse = await graphQLClient.SendQueryAsync(missionListRequest, () => new { getSortedLyrics = new GraphQLTrackListResponse() });
            return graphQLResponse.Data.getSortedLyrics.Items;
        }

        [Obsolete("This method is not well tested and sometimes doesn't work as intended. If you aren't aware of unexpected behaviour, go ahead :)")]
        public bool ReserveTask(string missionId, string resourceId, string type = "VERIFY") => ReserveTaskAsync(missionId, resourceId, type).GetAwaiter().GetResult();

        [Obsolete("This method is not well tested and sometimes doesn't work as intended. If you aren't aware of unexpected behaviour, go ahead :)")]
        public async Task<bool> ReserveTaskAsync(string missionId, string resourceId, string type = "VERIFY")
        {
            var createTaskRequest = new GraphQLRequest
            {
                Query = @"
                mutation CreateTask(
                	$appId: String
                	$missionId: ID!
                	$resourceId: ID!
                	$type: TaskType!
                	$userId: ID!
                	$userToken: String = null
                ) {
                	reserveResource(
                		input: {
                			appId: $appId
                			missionId: $missionId
                			resourceId: $resourceId
                			type: $type
                			userId: $userId
                			userToken: $userToken
                		}
                	) {
                		id
                		lastUpdated
                		status
                		type
                		missionId
                		resource {
                			id
                			actionURI
                			artistName
                			commonTrackId
                			hasLyrics
                			hasSync
                			language
                			missionId
                			publishedStatusMacro
                			rank
                			status
                			title
                			trackLength
                		}
                	}
                }
                ",
                OperationName = "CreateTask",
                Variables = new
                {
                    appId = requestFactory.Context.AppId,
                    missionId = missionId.Replace("MISSION.", string.Empty),
                    resourceId = resourceId,
                    type = type,
                    userId = userId,
                    userToken = requestFactory.UserToken
                }
            };
            try
            {
                await graphQLClient.SendQueryAsync<object>(createTaskRequest); // TODO: response (2 lazy 2 implement)
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Obsolete("This method is not well tested and sometimes doesn't work as intended. If you aren't aware of unexpected behaviour, go ahead :)")]
        public bool CancelTask(string missionId, string resourceId, string taskId, string type) => CancelTaskAsync(missionId, resourceId, taskId, type).GetAwaiter().GetResult();

        [Obsolete("This method is not well tested and sometimes doesn't work as intended. If you aren't aware of unexpected behaviour, go ahead :)")]
        public async Task<bool> CancelTaskAsync(string missionId, string resourceId, string taskId, string type)
        {
            var cancelTaskRequest = new GraphQLRequest
            {
                Query = @"
                mutation CancelTask(
                    $appId: String
                    $missionId: ID!
                    $resourceId: ID!
                    $taskId: ID!
                    $type: TaskType!
                    $userId: ID!
                    $userToken: String = null
                ) {
                    releaseResource(
                        input: {
                            appId: $appId
                            missionId: $missionId
                            resourceId: $resourceId
                            taskId: $taskId
                            type: $type
                            userId: $userId
                            userToken: $userToken
                        }
                    ) {
                        id
                        lastUpdated
                        status
                        type
                        resource {
                            id
                            actionURI
                            artistName
                            commonTrackId
                            hasLyrics
                            hasSync
                            language
                            missionId
                            publishedStatusMacro
                            rank
                            status
                            title
                            trackLength
                        }
                    }
                }
                ",
                OperationName = "CreateTask",
                Variables = new
                {
                    appId = requestFactory.Context.AppId,
                    missionId = missionId.Replace("MISSION.", string.Empty),
                    resourceId = resourceId,
                    taskId = taskId,
                    type = type,
                    userId = userId,
                    userToken = requestFactory.UserToken
                }
            };
            try
            {
                await graphQLClient.SendQueryAsync<object>(cancelTaskRequest); // TODO: response (2 lazy 2 implement)
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}