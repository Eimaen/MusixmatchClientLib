using System;
using System.Collections.Generic;
using System.Net;

namespace MusixmatchClientLib.Web.Cookie
{
    public class GlobalCookieContainer
    {
        private static GlobalCookieContainer _instance;

        private readonly Dictionary<Object, CookieContainer> _cookies;

        public GlobalCookieContainer()
        {
            this._cookies = new Dictionary<Object, CookieContainer>();
        }

        public CookieContainer GetCookieContainer(Object obj)
        {
            CookieContainer container = this._cookies[obj];

            if (container != null)
                return container;

            CookieContainer cookieContainer = new CookieContainer();
            this._cookies.Add(obj, cookieContainer);
            return cookieContainer;
        }

        public static GlobalCookieContainer INSTANCE
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalCookieContainer();

                return _instance;
            }
        }

    }
}
