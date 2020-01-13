using LicLZXL.Interfaces;
using LicLZXL.Singleton;
using Microsoft.Win32;
using RemoveLzgRegistryKey.Properties;
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

            try
            {
                

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format(
                    "http://www.lozenge-co.com/ltt/licenceReport.php?lic={0}&user={1}&host={2}",
                    checkLicence.DecodeData(checkLicence.GetRegistryKeyValue(Resources.RegistryKeyLicenceName)),
                    checkLicence.GetUserMachine(),
                    checkLicence.GetMachineName()));

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    checkLicence.DeleteKey();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
