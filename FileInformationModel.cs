using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHEQS.Common
{
    public class FileInformationModel
    {
        public string fileName { get; set; }
        public string ICLfileDate { get; set; }
        public string ICLbankCode { get; set; }
        public string fldPosPayType { get; set; }
        public string fileSize { get; set; }
        public string fileTimeStamp { get; set; }
        public string filebankcode { get; set; }
        public string filebankcode1 { get; set; }
        public string fileNameOnly { get; set; }
        public string fileClearDate { get; set; }
        public string fileStatus { get; set; }
        public string fileBankType { get; set; }
    }
    public class FolderInformationModel
    {
        public string folderName { get; set; }
        public string folderCount { get; set; }
        public string folderSize { get; set; }
        public string folderTimeStamp { get; set; }
    }
}
