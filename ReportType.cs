using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INCHEQS.Common {

    public class ReportType {
        public static Dictionary<string, string> Extensions = new Dictionary<string, string>(){
            { "PDF" , "pdf" },
            { "Excel" , "xlsx" },
            { "Word" , "doc" }
        };
    }
}