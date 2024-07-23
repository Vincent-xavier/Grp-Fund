using Fund_API.Framework.Helper;
using Newtonsoft.Json;

namespace Fund_API.Framework
{
    public class ConfSettings
    {
        public SMTPMailConfig SMTPMailConfig { get; set; }
    }

    public class SettingConfiguration
    {
        public SMTPMailConfig SMTPMailConfig { get; set; }
    }

    public class SMTPMailConfig
    {
        public string? SendMailFlag { get; set; }
        public string? SMTPServer { get; set; }
        public string? SMTPPort { get; set; }
        public string? DisplayName { get; set; }
        public string? MUserName { get; set; }
        public string? MPassword { get; set; }
        public string? IsSSLEnabled { get; set; }
        public string? ContactUsMailId { get; set; }
        public string? CCMailId { get; set; }
        public string? LoginURL { get; set; }
        public string? BCCMailId { get; set; }
        public string? DefaultToAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? LogoUrl { get; set; }

    }
    public class ConfSettingsService
    {
        public ConfSettings Settings = new();

        public ConfSettingsService()
        {
            Settings = LoadData();
        }

        /// <summary>
        /// To get the Value from json files
        /// </summary>
        /// <returns></returns>
        public ConfSettings LoadData()
        {
            ConfSettings confSettings = new ConfSettings();
            try
            {
                string sBaseDirectory = (AppDomain.CurrentDomain.BaseDirectory).Replace(@"\bin\Debug\net8.0", "");
                string sCSSFileName = sBaseDirectory + @"\_configurationSettings.json";
                string jsonString = System.IO.File.ReadAllText(sCSSFileName);
                confSettings = JsonConvert.DeserializeObject<ConfSettings>(jsonString.ToString());
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return confSettings;
        }

    }
}