namespace SchoolProject.Data.Router
{
    public static class Router
    {
        internal const string singleroute = "/{id}";
        internal const string update = "/update/";
        internal const string paginate = "/Paginate/";
        internal const string delete = "/delete/";
        internal const string root = "Api";
        internal const string version = "V1";
        internal const string Rule = root+"/"+version;//API/V1
        public static class Student
        {
            public const string perfix = Rule + "/Student";//API/V1/Student
            public const string GetAll = perfix + "/List";//Api/V1/Student/List
            public const string GetById = perfix +singleroute;//Api/V1/Student/{id}
            public const string Update = perfix + update;//Api/V1/Student/update
            public const string Delete = perfix + delete;//Api/V1/Student/delete
            public const string Paginate = perfix + paginate;//Api/V1/Student/Paginate
        }
        public static class Department
        {
            public const string perfix = Rule + "/Department";//API/V1/Department
            public const string GetAll = perfix + "/List";//Api/V1/Department/List
            public const string GetById = perfix + singleroute;//Api/V1/Department/{id}
            public const string Update = perfix + update;//Api/V1/Department/update
            public const string Delete = perfix + delete;//Api/V1/Department/delete
            public const string Paginate = perfix + paginate;//Api/V1/Department/Paginate
        }
    }
}
