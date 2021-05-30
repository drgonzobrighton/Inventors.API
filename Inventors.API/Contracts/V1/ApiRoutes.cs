namespace Inventors.API.V1.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Inventors
        {
            public const string GetAll = Base + "/" + "inventors";
            public const string Get = Base + "/" + "inventors/{id}";
            public const string Create = Base + "/" + "create";
            public const string Update = Base + "/" + "update/{id}";
            public const string Delete = Base + "/" + "delete/{id}";
        }
    }
}
