
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Configuration;

namespace INCHEQS.Common
{

    public class Utils
    {
        public static string getMacAddress()
        {
            System.Net.NetworkInformation.NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            return nics[0].GetPhysicalAddress().ToString();
        }

        public static string getRemoteAddress(HttpRequestBase Request)
        {
            return Request.UserHostAddress;
        }


        public static Dictionary<string, string> ConvertFormCollectionToDictionary(FormCollection formCollection)
        {
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (var key_loopVariable in formCollection.AllKeys)
            {
                form.Add(key_loopVariable, formCollection[key_loopVariable]);
            }
            return form;
        }

        public static List<FileInformationModel> GetFileInFolder(string folderName) {

            string[] filePath = Directory.GetFiles(folderName);
            List<FileInformationModel> filesList = new List<FileInformationModel>();

            foreach (var item in filePath) {
                FileInformationModel fileInfoModel = new FileInformationModel();
                FileInfo fileInfo = new FileInfo(item);

                fileInfoModel.fileName = Path.GetFileName(item);
                fileInfoModel.fileSize = fileInfo.Length.ToString();

                DateTime creationTime = fileInfo.CreationTime;
                fileInfoModel.fileTimeStamp = DateUtils.formatTimeStampFromSql(creationTime.ToString());

                filesList.Add(fileInfoModel);
            }
            return filesList;
            
        }

        //public static string getdateformat()
        //{
        //    return configurationmanager.appsettings["dateformat"];
        //}

        //public static string GetTimeStampFormat()
        //{
        //    return  ConfigurationManager.AppSettings["TimeStampFormat"];
        //}

        //public static string GetTempFolderPath()
        //{
        //    return ConfigurationManager.AppSettings["TempFolderPath"];
        //}


        public static List<Dictionary<string, string>> ConvertDataTableToList(DataTable dataTable) {

            List<Dictionary<string, string>> lst = dataTable.AsEnumerable()
                .Select(r => r.Table.Columns.Cast<DataColumn>()
                        .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                       ).ToDictionary(z => z.Key, z => z.Value.ToString())
                ).ToList();

            return lst;
        }

        public static Dictionary<string,string> ConvertFirstRowToDictionary(DataTable dataTable) {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (dataTable.Rows.Count > 0) {
                DataRow row = dataTable.AsEnumerable().FirstOrDefault();
                result = row.Table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => row[col.Ordinal].ToString());
            }
            return result;
        }



    }
}