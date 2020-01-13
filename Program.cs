using LicLZXL.Interfaces;
using LicLZXL.Singleton;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RemoveLzgRegistryKey
{
    class Program
    {

        static void Main(string[] args)
        {
            var checkLicence = CheckLicenceSingleton.GetInstance();
   
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format(
                "http://www.lozenge-co.com/ltt/licenceReport.php?lic={0}&user={1}&host={2}",
                checkLicence.DecodeData(checkLicence.GetRegistryKeyValue("LzLiN")),
                checkLicence.GetUserMachine(),
                checkLicence.GetMachineName()));
                
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

        }
    }
}
