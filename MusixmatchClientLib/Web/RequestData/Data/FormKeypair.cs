namespace MusixmatchClientLib.Web.RequestData.Data
{
    public class FormKeypair
    {
        private string _key;
        private string _value;

        public FormKeypair(string key, string value)
        {
            this._key = key;
            this._value = value;
        }

        public string Key
        {
            get => this._key;
            set => this._key = value;
        }

        public string Value
        {
            get => this._value;
            set => this._value = value;
        }
    }
}
