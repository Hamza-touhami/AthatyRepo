namespace AthatyCore.Settings
{
    public class MongoDBSettings
    {
        public string Host {get;init;} = null!;
        public int Port {get;init;}
        public string ConnectionToken
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}