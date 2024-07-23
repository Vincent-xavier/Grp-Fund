namespace Fund_API.Framework
{
    public static class AuthAPIController
    {
        public static class InputType
        {
            public const string ApplicationJson = "application/json";
            public const string Text = "Text";
        }
        public static class Property
        {
            public const string APIController = "api/[controller]/[action]";
            public const string AllowOrigin = "AllowOrigin";
        }
        public static class SwaggerModuleDoc
        {
            public const string Fund_APIMaster = "Fund_API.Master";
            public const string Fund_APIWebSiteRequest = "Fund_API.WebSiteRequest";
            public const string Fund_APICustomers = "Fund_API.Customers";
            public const string Fund_APIDocumentLibrary = "Fund_API.DocumentLibrary";
            public const string Fund_APIAuth = "Fund_API.Auth";
            public const string Fund_APICommon = "Fund_API.Common";
            public const string Fund_APISupportTicket = "Fund_API.SupportTicket";
            public const string Fund_APIInvoice = "Fund_API.Invoice";
            public const string Fund_APIInvoiceItem = "Fund_API.InvoiceItem";
            public const string Fund_APIService = "Fund_API.Fund_APIService";
        }
    }
}
