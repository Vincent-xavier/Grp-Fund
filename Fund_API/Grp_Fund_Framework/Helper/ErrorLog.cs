namespace Fund_API.Framework.Helper
{

    /// <summary>
    /// Summary description for ErrorLog new 
    /// </summary>
    public class ErrorLog : IDisposable
    {
        #region Properties
        private static readonly string LogFilePath = Path.Combine(AppContext.BaseDirectory, "errorlog", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString());
        private readonly string LogFileName = string.Concat(LogFilePath.TrimEnd('/'), @"/log_", DateTime.Today.ToShortDateString().Replace("/", "_"), ".log");
        #endregion Properties

        public ErrorLog()
        {
            //check if the directory exists
            if (!Directory.Exists(LogFilePath))
            {
                Directory.CreateDirectory(LogFilePath);
            }
        }
        /// <summary>
        /// This method is to write the passed error message and other details of error occurence
        /// </summary>
        /// <param name="sMessage">string - Error message</param>
        ///
        public void WriteLog(string sMessage)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogFileName);
                sw.WriteLine("Date/Time : " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("Message   : " + sMessage);
                sw.Close();
            }
            catch (Exception)
            {
            }
        }

        public void WriteLog(Exception ex)
        {
            try
            {
                if (ex != null)
                {
                    StreamWriter sw = File.AppendText(LogFileName);
                    sw.WriteLine("-----------------------------------------------------------------------------------------");
                    sw.WriteLine("Date/Time  :" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                    sw.WriteLine("Source/MSG :" + ex.Source + " / " + ex.Message);
                    sw.WriteLine("StackTrace :" + ex.StackTrace);
                    sw.WriteLine("-----------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Method used to write the exception passed an an arugement to targetted text file
        /// in a new line
        /// </summary>
        /// <param name="ex"></param>
        public void WriteLog(string className, string methodName, string query, string errMessage)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogFileName);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.WriteLine("Date/Time  :" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("ClassName  :" + className);
                sw.WriteLine("MethodName :" + methodName);
                if (!string.IsNullOrEmpty(query))
                {
                    sw.WriteLine("Query      :" + query);
                }

                sw.WriteLine("Message    :" + errMessage);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.Close();
            }
            catch (Exception)
            {
            }
            WriteLog("-----------------------------------------------------------------------------------------");
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}