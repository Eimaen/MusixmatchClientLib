using System;
using System.Collections.Generic;
using System.Net;

namespace MusixmatchClientLib.Web.Cookie
{
    public class GlobalCookieContainer
    {
        private static GlobalCookieContainer _instance;

        private readonly List<Tuple<Object, CookieContainer>> _cookies;

        public GlobalCookieContainer()
        {
            this._cookies = new List<Tuple<Object, CookieContainer>>();
        }

        public CookieContainer GetCookieContainer(Object obj)
        {
            CookieContainer container = FindContainer(obj);

            if (container != null)
                return container;

            CookieContainer cookieContainer = new CookieContainer();
            this._cookies.Add(new Tuple<object, CookieContainer>(obj, cookieContainer));
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

        private CookieContainer FindContainer(Object obj)
        {
            for (int i = 0; i < this._cookies.Count; i++)
            {
                Tuple<Object, CookieContainer> entry = this._cookies[i];

                if (entry.Item1 == obj)
                    return entry.Item2;
            }

            return null;
        } 

    }
}
