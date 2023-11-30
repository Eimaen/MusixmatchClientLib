using System;
using System.Collections.Generic;
using System.Linq;

namespace MusixmatchClientLib.API.Contexts
{
    public class MusixmatchApiContext
    {
        private static Dictionary<ApiContext, MusixmatchApiContext> Clients = new Dictionary<ApiContext, MusixmatchApiContext>
        {
            [ApiContext.Web] = new MusixmatchApiContext
            {
                ApiUrl = @"https://www.musixmatch.com/ws/1.1/",
                AppId = @"community-app-v1.0",
                RequiresSignature = true
            },
            [ApiContext.Desktop] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic-desktop.musixmatch.com/ws/1.1/",
                AppId = @"web-desktop-app-v1.0",
                RequiresSignature = true
            },
            [ApiContext.iOS] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic.musixmatch.com/ws/1.1/",
                AppId = @"mac-ios-v2.0",
                RequiresSignature = true
            },
            [ApiContext.AuthWeb] = new MusixmatchApiContext
            {
                ApiUrl = @"https://account.musixmatch.com/ws/1.1/",
                RequiresSignature = false
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
        public static ApiContext Recover(MusixmatchApiContext apiContext) => Clients.Where(element => element.Value == apiContext).First().Key;

        public string AppId { get; private set; }
        public string ApiUrl { get; private set; }
        public bool RequiresSignature { get; private set; }
    }
}
