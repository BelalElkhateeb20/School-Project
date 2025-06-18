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
        public static class User
        {
            public const string perfix = Rule + "/User"; // Corrected to API/V1/User
            public const string GetAll = perfix + "/List"; // API/V1/User/List
            public const string GetById = perfix + singleroute; // API/V1/User/{id}
            public const string Update = perfix + update; // API/V1/User/update
            public const string Delete = perfix + delete; // API/V1/User/delete
            public const string Paginate = perfix + paginate; // API/V1/Authentication/Paginate
            public const string ChangeUserPassward = perfix + "/ChangeUserPassward"; // API/V1/Authentication/ChangeUserPassward
            public const string AddUser = perfix + "/AddUser"; // API/V1/Authentication/ChangeUserPassward
        }
        public static class Authentication
        {
            public const string perfix = Rule + "/Authentication"; // Corrected to API/V1/Authentication
            public const string perfix2 = "Authentication"; // Corrected to Authentication
            public const string ChangeUserPassward = perfix + "/ChangeUserPassward"; // API/V1/User/ChangeUserPassward
            public const string SignIn = perfix + "/SignIn"; 
            public const string RefreshToken = perfix + "/RefreshToken"; 
            public const string ValidateToken = perfix + "/ValidateToken"; 
            public const string ConfirmEmail = perfix2+ "/ConfirmEmailAsync";

        }
        public static class Authorization
        {
            public const string perfix = Rule + "/Authorization"; // Corrected to API/V1/Authorization
            public const string GetAll = perfix + "/List"; // API/V1/Authorization/List
            public const string GetById = perfix + singleroute; // API/V1/Authorization/{id}
            public const string Update = perfix + update; // API/V1/Authorization/update
            public const string Delete = perfix + delete; // API/V1/Authorization/delete
            public const string Paginate = perfix + paginate; // API/V1/Authorization/Paginate
            public const string ChangeUserPassward = perfix + "/ChangeUserPassward"; // API/V1/Authorization/ChangeUserPassward
            public const string SignIn = perfix + "/SignIn";
            public const string RefreshToken = perfix + "/RefreshToken";
            public const string ValidateToken = perfix + "/ValidateToken";
            public const string AddRole = perfix + "/AddRole"; // API/V1/Authorization/AddRole

        }
        public static class Email
        {
            public const string perfix = Rule + "/Email"; // Corrected to API/V1/Email
            public const string GetAll = perfix + "/List"; // API/V1/Email/List
            public const string GetById = perfix + singleroute; // API/V1/Email/{id}
            public const string Update = perfix + update; // API/V1/Email/update
            public const string Delete = perfix + delete; // API/V1/Email/delete
            public const string Paginate = perfix + paginate; // API/V1/Email/Paginate
            public const string ChangeUserPassward = perfix + "/ChangeUserPassward"; // API/V1/Email/ChangeUserPassward
            public const string SignIn = perfix + "/SignIn";
            public const string RefreshToken = perfix + "/RefreshToken";
            public const string ValidateToken = perfix + "/ValidateToken";
            public const string SendEmail = perfix + "/SendEmail"; // API/V1/Email/SendEmail

        }
    }
}
