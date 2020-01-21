namespace ereferee.Helpers
{
    public static class Api
    {
        public const string Url = "https://localhost"; //ereferee-server url

        //Authentication
        public const string SignIn = "/api/Auth/signIn";
        public const string SignUp = "/api/Auth/signUp";

        //Match
        public const string CreateMatch = "/api/match/createMatch";
        public const string BeginMatch = "/api/match/beginMatch";
        public const string FinishMatch = "/api/match/finishMatch";
        public const string GetPendingMatches = "/api/match/getPendingMatchs";
        public const string GetPendingMatchById = "/api/match/getPendingMatchByID";
        public const string GetActiveMatches = "/api/match/getActiveMatchs";
        public const string GetActiveMatchById = "/api/match/getActiveMatchByID";
        public const string GetPreviousMatches = "/api/match/getPreviousMatchs";
        public const string GetPreviousMatchById = "/api/match/getPreviousMatchByID";
        public const string CreateMatchEvents = "/api/match/createMatchEvents";
        public const string DeleteMatch = "/api/match/deleteMatch";

        //User
        public const string ResetPassword = "/api/user/resetPassword";
        public const string ChangePassword = "/api/user/changePassword";
        public const string GetUserInfo = "/api/user/getUserInfo";
        public const string GetAllUsers = "/api/user/getAllUsers";
    }
}
