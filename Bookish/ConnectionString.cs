namespace Bookish
{
    public sealed class ConnectionString
    {
        public ConnectionString(string value) => Value = value;

        public ConnectionString()
        {
            throw new System.NotImplementedException();
        }

        public string Value { get; }
    }
}