using MusixmatchClientLib;
using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenString = string.Empty;
            if (File.Exists("token.mxm"))
                tokenString = File.ReadAllText("token.mxm");
            else
                File.WriteAllText("token.mxm", (tokenString = new MusixmatchToken().Token));
            MusixmatchToken token = new MusixmatchToken(tokenString);
            MusixmatchClient client = new MusixmatchClient(token);
            Console.WriteLine(client.GetUserInfo().UserData.UserId);
            Console.ReadKey();
        }
    }
}
