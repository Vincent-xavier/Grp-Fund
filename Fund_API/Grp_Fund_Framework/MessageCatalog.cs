namespace Fund_API.Framework
{
    public static class MessageCatalog
    {
        public static class ErrorCodes
        {
            public const int Success = 200;
            public const int Created = 201;
            public const int Updated = 202;
            public const int Failed = 203;
            public const int NoRecordFound = 204;
            public const int Deleted = 205;
            public const int Exist = 206;
            public const int InValidToken = 207;

            public const int BadRequest = 400;
            public const int UnAuthorized = 401;
            public const int RequestTimeOut = 408;
            public const int ServiceTimeout = 440;
            public const int InvalidCredentials = 422;
            public const int PreconditionFailed = 412;
            public const int MemberScheduleAlready = 100;
            public const int MemberSchedule = 101;
            public const int KHIDAlreadyExist = -98;
            public const int CaseNumberAlreadyExist = -97;
            public const int AlreadyExist = -99;
            public const int InternalServerError = 500;
        }
        public static class ErrorMessages
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string Exist = "Record Exist";
            public const string ListSuccess = "Success";
            public const string ListFailed = "Unable to get the record.";

            public const string UserNameNotExists = "Username is invalid";
            public const string PasswordIncorrect = "Password is invalid";

            public const string SaveSuccess = "Saved successfully.";
            public const string SaveFailed = "Unable to save record.";

            public const string DeleteSuccess = "Deleted successfully.";
            public const string DeleteFailed = "Unable to delete record.";

            public const string NoRecordFound = "No record found.";
            public const string RecordReferred = "Record referred.";

            public const string InValidKey = "Invalid key";
            public const string InValidToken = "Invalid token";

            public const string ParmeterRequied = "Parameter is required";
            public const string ExpectationFailed = "Unexpected error occurred while processing the data,Please check your inputs";

            public const string BadRequest = "The request was invalid or cannot be served. The exact error should be explained in the error payload as above.";
            public const string Unauthorised = "The request requires an user authentication.";
            public const string Forbidden = "The server understood the request, but is refusing it or the access is not allowed.";
            public const string Notfound = "There is no resource behind the URL.";
            public const string ServiceUnavailable = "Service unavailable.";

            public const string NoBarcode = "Barcode not found, Please use current barcode";
            public const string StudentNotYetRegister = "Student not yet register for current term";
            public const string NotYetRegisterForMealsCount = "You are either not registered or it is an invalid barcode. please contact your homeroom teacher.";
            public const string GoToMealsCountPage = "Meals count is not taken for today, Do you wish to take meals count now?";

            public const string MemberScheduleAlready = "Some members are already scheduled.Are you sure you want to schedule?";
            public const string MemberSchedule = "Are you sure you want to schedule this member?";

            public const string InternalServerError = "Sorry, something went wrong on our end. We're working to fix the issue. Please try again later.";
        }

        public static class InfoMessages
        {
            public const string ActivationSuccess = "Activated Successfully.";
            public const string AreadyActivaded = "This system is already activated with a productkey.";
            public const string InvalidKey = "Product Key is not valid.";
        }

    }
}