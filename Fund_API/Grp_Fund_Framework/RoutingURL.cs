namespace Fund_API.Framework
{

    public static class RoutingURL
    {
        //COMMON
        public const string SetExportOptions = "Set-Export-Options";
        public const string ExportData = "Export-data";

        public static class Sample
        {
            public const string SampleAdd = "sample-add";
            public const string SampleView = "sample-view";
        }
        public static class UserDetails
        {
            public const string AddUserDetails = "add-user-details";
            public const string ViewUserDetails = "user-details";
            public const string UserRole = "user-role";

        }
        public static class SupportData
        {
            public const string ViewSupportData = "support-data";
        }
        public static class UserRights
        {
            public const string ListUserRights = "user-rights";

        }

        public static class Invoice
        {
            public const string InvoiceDetails = "invoice-details";
            public const string CreateInvoice = "create-invoice";
            public const string InvoiceItems = "invoice-items";
            public const string Invoicesettings = "invoice-settings";
            public const string GenerateInvoice = "generate-invoice";
        }

        public static class AreaName
        {
            public const string Administration = "Administration";
            public const string ContactUs = "ContactUs";
        }

        public static class Home
        {
            public const string Index = "dashboard";
            public const string Dashboard = "dashboard";
            public const string PDFViewer = "pdf-viewer";
        }

        public static class Login
        {
            public const string AuthUserLogin = "auth-user-login";
            public const string Authenticate = "authenticate";
            public const string AutoAuthenticate = "auto-authenticate";
            public const string Logout = "logout";
        }

        public static class Customer
        {
            public const string CustomerAdd = "customer-add";
            public const string ViewCustomers = "view-customers";
            public const string SaveCustomer = "save-customer";
            public const string ViewCustomer = "view-customer";
            public const string Addusers = "add-users";
        }
        public static class ContactUs
        {
            public const string Index = "contact-us";
            public const string SwitchProduct = "SwitchProduct";
        }

        public static class SupportTicket
        {
            public const string ViewTickets = "view-tickets";
            public const string TicketStatistic = "ticket-statistic";
            public const string AddTicket = "add-new-ticket";
        }
        public static class DocumentLibrary
        {
            public const string ViewDocumentLibrary = "view-documentlibrary";
            public const string AddDocumentLibrary = "add-documentlibrary";
            public const string ViewDocuments = "view-documents";
        }
    }

}
