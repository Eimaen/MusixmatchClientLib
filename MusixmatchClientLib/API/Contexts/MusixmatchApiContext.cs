﻿using System.Collections.Generic;

namespace MusixmatchClientLib.API.Contexts
{
    public class MusixmatchApiContext
    {
        private static Dictionary<ApiContext, MusixmatchApiContext> Clients = new Dictionary<ApiContext, MusixmatchApiContext>
        {
            // TODO: android context check
            [ApiContext.Desktop] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic-desktop.musixmatch.com/ws/1.1/",
                AppId = @"web-desktop-app-v1.0"
            },
            [ApiContext.iOS] = new MusixmatchApiContext
            {
                ApiUrl = @"https://apic.musixmatch.com/ws/1.1/",
                AppId = @"mac-ios-v2.0"
            },
            [ApiContext.CommunityOld] = new MusixmatchApiContext
            {
                ApiUrl = @"https://musixmatch.com/ws/1.1/",
                AppId = @"community-app-v1.0"
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

        public string AppId { get; private set; }
        public string ApiUrl { get; private set; }
    }
}
