using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace SKB_Master {
    [ Serializable() ]
    public class LogPost : IEquatable< LogPost > {
        public string status;
        public string timeStamp;
        public string details;
        public string reportingClass;
        
        public LogPost( string reportingClass, string status, string details = "" ) {
            timeStamp = DateTime.Now.ToString();
            this.reportingClass = reportingClass;
            this.status = status;
            this.details = details;
        }

        public LogPost() {
            status = null;
            timeStamp = null;
            details = null;
            reportingClass = null;
        }

        public bool Equals( LogPost other ) {
            if ( status == other.status &&
                 timeStamp == other.timeStamp &&
                 details == other.details &&
                 reportingClass == other.reportingClass ) {
                return true;
            }
            return false;
        }
    }
}
