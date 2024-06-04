namespace DummyAPI.Utilitites
{
    public class LogWriter
    {
        public static void Log(string logMessage)
        {
            DateTime currentDate = DateTime.Now;
            string dateFormat = "yyyyMMdd";
            string filePath = "D:\\DummyAPILogs\\";
            string nameFile = "DummyAPILog_";
            string fileExt = ".log";

            string fileName = filePath + nameFile + currentDate.ToString(dateFormat) + fileExt;

            try
            {
                // File Creation
                if (!File.Exists(fileName))
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("DummyAPILogger");
                        sw.Dispose();
                        sw.Close();
                    }
                }

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.Write($"{DateTime.Now.ToString()}");
                    sw.WriteLine($"| {logMessage}");
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("**********************************");
                    sw.WriteLine(ex.ToString());
                    sw.WriteLine("**********************************");
                }
            }
        }
    }
}
