using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SKB_Master {
    public class Log {
        //
        // TODO: This is now using Properties.Settings to save the log. It should be saved as a file in an appropriate place instead.
        //
        private string reportingClassName;
        IUpdateUI uiToUpdate;
        static string logPostsFilename = "log.xml";

        public Log( string reportingClassName, IUpdateUI uiToUpdate = null ) {
            this.reportingClassName = reportingClassName;
            this.uiToUpdate = uiToUpdate;
        }

        public void AddLog( string status, string details = "" ) {
            List<LogPost> logList = loadLogs();
            logList.Add( new LogPost( this.reportingClassName, status, details ) );
            saveLogs( logList );

            if ( uiToUpdate != null ) {
                uiToUpdate.UpdateUI();
            }
        }

        public List<LogPost> getLog() {
            return loadLogs();
        }

        void saveLogs( List<LogPost> logPosts ) {
            string filePath = Environment.ExpandEnvironmentVariables( Properties.Settings.Default.logFileLocation + logPostsFilename );
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( List<LogPost> ) );
            int tries = 0; // Try and retry by Adriaan Stander, copy pasted from https://stackoverflow.com/questions/18704613/how-to-implement-retry-abort-mechanism-for-writing-files-that-may-be-used-by-a
            bool completed = false;
            while ( !completed ) {
                try {
                    TextWriter fileStream = new StreamWriter( filePath );
                    xmlSerializer.Serialize( fileStream, logPosts );
                    fileStream.Close();
                    completed = true;
                } catch ( Exception exc ) {
                    tries++;
                    // You could possibly put a thread sleep here
                    if ( tries == 5 )
                        break;
                }
            }
        }

        List<LogPost> loadLogs() {
            string filePath = Environment.ExpandEnvironmentVariables( Properties.Settings.Default.logFileLocation + logPostsFilename );
            if ( File.Exists( filePath ) ) {
                XmlSerializer xmlSerializer = new XmlSerializer( typeof( List<LogPost> ) );
                List<LogPost> logPosts = new List<LogPost>();
                int tries = 0; // Try and retry by Adriaan Stander, copy pasted from https://stackoverflow.com/questions/18704613/how-to-implement-retry-abort-mechanism-for-writing-files-that-may-be-used-by-a
                bool completed = false;
                while ( !completed ) {
                    try {
                        TextReader fileStream = new StreamReader( filePath );
                        logPosts = xmlSerializer.Deserialize( fileStream ) as List<LogPost>;
                        fileStream.Close();
                        completed = true;
                    } catch ( Exception exc ) {
                        tries++;
                        // You could possibly put a thread sleep here
                        if ( tries == 5 )
                            break;
                    }
                }
                return logPosts;
            }
            return new List<LogPost>();
        }
    }
}