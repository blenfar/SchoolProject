namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "api";
        public const string version = "v1";
        public const string rule = root + "/" +version;

        public static class StudentRouting
        {
            private const string student = "Student";
            private const string attributList = "List";

            public const string Prefix = rule+"/"+student;
            public const string List = Prefix + "/" + attributList;
            public const string GetByID = Prefix+"/{id}";
            public const string Create = Prefix+"/create";
        }
    }
}
