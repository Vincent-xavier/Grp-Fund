namespace Fund_API.Framework
{
    public static class DBParameterName
    {
        public const string UserName = nameof(UserName);
        public const string Password = nameof(Password);

        public static class AttendanceLog
        {
            public const string StartDate = nameof(StartDate);
            public const string EndDate = nameof(EndDate);
            public const string SerialNumber = nameof(SerialNumber);
        }

        public static class EmployeeDetails
        {
            public const string DeviceId = nameof(DeviceId);
            public const string DeviceName = nameof(DeviceName);
            public const string SerialNumber = nameof(SerialNumber);
        }
        public static class SupportData
        {
            public const string FieldId = nameof(FieldId);
            public const string DataId = nameof(DataId);
            public const string Name = nameof(Name);
            public const string Description = nameof(Description);
            public const string Active = nameof(Active);
        }
        public static class ContactUs
        {
            public const string Id = nameof(Id);
            public const string WebSiteId = "website_id";
            public const string Name = nameof(Name);
            public const string Description = nameof(Description);
            public const string Active = nameof(Active);
        }
        public static class UserRights
        {
            public const string RoleId = nameof(RoleId);
            public const string UserId = nameof(UserId);
        }
        public static class CommonFields
        {
            public const string RowsAffected = "p_rows_affected";
        }
        public static class DocumentLibrary
        {
            public const string Id = nameof(Id);
            public const string Title = nameof(Title);
            public const string FileUpload = nameof(FileUpload);
            public const string PostDate = nameof(PostDate);
            public const string FileType = nameof(FileType);
            public const string LengthofVideo = nameof(LengthofVideo);
            public const string IsThisPartOfSeries = nameof(IsThisPartOfSeries);
            public const string SeriesName = nameof(SeriesName);
            public const string SequenceInSeries = nameof(SequenceInSeries);
            public const string FileName = nameof(FileName);
            public const string FilePath = nameof(FilePath);
            public const string UniqueFileName = nameof(UniqueFileName);
            public const string WebsiteId = nameof(WebsiteId);

        }
    }

}
