namespace Fund_API.Framework
{
    public static class CommonVariable
    {
        //GemBox (Excel Export) Details
        public static class GemBoxSettings
        {
            public const string LicenseKey = "EDWG-UK8O-D78A-OMUQ";
        }
        public static class DefaultValue
        {
            public const string Select = "Select";
            public const string Empty = "";
            public const string One = "1";
            public const string AllFAQs = "-1";
            public const string ToastrMessage = "ToastrMessage";
            public const string Delete = "Delete";
        }
        public static class TempDataField
        {
            public const string FormId = "FormId";
            public const string ToastrMessage = "ToastrMessage";
            public const string Message = "Message";
        }
        public static class ViewBagField
        {
            public const string FormId = "vb_FormId";
        }
        /// <summary>
        /// To handle common session variable
        /// </summary>
        public static class SessionField
        {
            public const string UserId = nameof(UserId);
            public const string UserName = nameof(UserName);
            public const string Password = nameof(Password);
            public const string FirstName = nameof(FirstName);
            public const string LastName = nameof(LastName);
            public const string RoleId = nameof(RoleId);
            public const string WebSiteId = nameof(WebSiteId);
            public const string ActiveProductName = nameof(ActiveProductName);
            public const string SecondaryProducts = nameof(SecondaryProducts);
            public const string Token = nameof(Token);
            public const string Email = nameof(Email);
            public const string UserRights = nameof(UserRights);
        }
        public static class BtnStatus
        {
            public const string Active = nameof(Active);
        }
    }
    public static class AreaNames
    {
        public const string Administration = nameof(Administration);
        public const string Customers = nameof(Customers);
        public const string SupportTicket = nameof(SupportTicket);
        public const string Invoice = nameof(Invoice);
        public const string ProductKeyManager = nameof(ProductKeyManager);
        public const string DocumentLibrary = nameof(DocumentLibrary);
    }

    public static class ControllerName
    {
        public const string Home = nameof(Home);
        public const string Authentication = nameof(Authentication);
    }

    public static class ActionName
    {
        public const string Index = nameof(Index);
        public static class TimeLogAction
        {
            public const string ProjectTimelog = nameof(ProjectTimelog);
        }
    }

    public static class DBParameter
    {
        public const string user_id = nameof(user_id);
        public const string CustomerId = nameof(CustomerId);
        public const string user_name = nameof(user_name);
        public const string first_name = nameof(first_name);
        public const string last_name = nameof(last_name);
        public const string password = nameof(password);
        public const string email = nameof(email);
        public const string contact_no = nameof(contact_no);
        public const string dob = nameof(dob);
        public const string address1 = nameof(address1);
        public const string address2 = nameof(address2);
        public const string city = nameof(city);
        public const string state = nameof(state);
        public const string country = nameof(country);
        public const string user_image = nameof(user_image);
        public const string role_id = nameof(role_id);
        public const string created_date = nameof(created_date);
        public const string modified_date = nameof(modified_date);
        public const string isdelete = nameof(isdelete);
        public const string isactive = nameof(isactive);
        public const string token = nameof(token);
        public const string Primary_site = nameof(Primary_site);
        public const string Secondary_sites = nameof(Secondary_sites);
        public const string Ids = nameof(Ids);
        public const string IsAdmin = nameof(IsAdmin);
        public static class Administration
        {
            public const string RoleId = nameof(RoleId);
            public const string RoleName = nameof(RoleName);
            public const string Description = nameof(Description);
        }
    }

    public enum InvoiceStatus
    {
        Created = 1,
        Paid = 2,
        Canceled = 3,
        Overdue = 4
    }

}