using MusixmatchClientLib.Enum;

namespace MusixmatchClientLib.Web.RequestData.Data
{
    public class Auth
    {
        private string _token;
        private EnumAuthType _authType;

        public Auth(string token, EnumAuthType authType)
        {
            this._token = token;
            this._authType = authType;
        }

        public string Token
        {
            get => this._token;
            set => this._token = value;
        }

        public EnumAuthType AuthType
        {
            get => this._authType;
            set => this._authType = value;
        }
    }
}
