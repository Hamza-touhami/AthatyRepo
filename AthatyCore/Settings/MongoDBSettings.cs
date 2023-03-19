namespace AthatyCore.Settings
{
    public class MongoDBSettings
    {
        public string Database {get;init;}= null!;
        public string Host {get;init;} = null!;
        public int Port {get;init;}
        public string username {get;init;}= null!;
        public string Password {get;init;}= null!;

        public string ConnectionToken
        {
            get
            {
                return $"mongodb://{username}:{Password}@{Host}:{Port}/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@athatydb@";
            }
        }
    }
}