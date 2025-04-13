namespace SchoolProject.Data.Router
{
    public static class Router
    {
        internal const string singleroute = "{id}";
        internal const string update = "update";
        internal const string root = "Api";
        internal const string version = "V1";
        internal const string Rule = root+"/"+version;
        public static class Student
        {
            public const string perfix = Rule + "/Student";
            public const string GetAll = perfix + "/List";
            public const string GetById = perfix +singleroute;
            public const string Update = perfix + update;
        }
    }
}
