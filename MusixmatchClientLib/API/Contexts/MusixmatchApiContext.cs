using System;
using System.Collections.Generic;
using System.Linq;

namespace MusixmatchClientLib.API.Contexts
{
    public class MusixmatchApiContext
    {
        private static Dictionary<ApiContext, MusixmatchApiContext> Clients = new Dictionary<ApiContext, MusixmatchApiContext>
        {
            // TODO: android context check
            // TODO: community context check
            [ApiContext.Desktop] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic-desktop.musixmatch.com/ws/1.1/",
                AppId = @"web-desktop-app-v1.0"
            },
            [ApiContext.iOS] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic.musixmatch.com/ws/1.1/",
                AppId = @"mac-ios-v2.0"
            }
            // AppId = @"api-php"
            // TODO: research
        };

        /// <summary>
        /// Get API context
        /// </summary>
        /// <param name="context">API context type</param>
        /// <returns>MusixmatchApiContext</returns>
        public static MusixmatchApiContext Get(ApiContext context) => Clients[context];

        /// <summary>
        /// Get <see cref="ApiContext"/> from <see cref="MusixmatchApiContext"/>
        /// </summary>
        /// <param name="apiContext"><see cref="MusixmatchApiContext"/> to get</param>
        /// <returns><see cref="ApiContext"/> enum value</returns>
        [Obsolete("This method is a temporary placeholder, is very uneffective and has to be removed in next releases.", false)]
        public static ApiContext Recover(MusixmatchApiContext apiContext) => Clients.Where(element => element.Value == apiContext).First().Key;

        public string AppId { get; private set; }
        public string ApiUrl { get; private set; }
    }
}
