//
// AUTOUPDATE.CS 
//
// Copyright (c) 2009 PhatStudio development team (Jeremy Stone et al)
// 
// This file is part of PhatStudio.
//
// PhatStudio is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// PhatStudio is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with PhatStudio. If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Net;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Win32;
using System.Reflection;

namespace PhatStudio
{
    public static class AutoUpdate
    {
        public static string LatestVersion;
        public static string DownloadUrl;

        private static string lastCheckTimestamp;
        private static string CRC;

        private const int AutoUpdateCheckIntervalDays = 1; 
        private const string RegKeyName = @"Software\PhatStudio\AutoUpdate";        
        private const string RegValueLastUpdateCheck = "LastUpdateCheck";
        private const string RegValueLatestVersion = "LatestVersion";
        private const string RegValueDownloadUrl = "DownloadUrl";
        private const string RegValueCRC = "CRC";
        private const string UpdateXmlUrl = "http://phatstudio.sourceforge.net/update.php";

        static public void OnFeatureUsed()
        {
            // Check for an update, if we haven't already today
            CheckForUpdateIfNecessary();
        }

        /// <summary>
        /// Checks the product website to see if a new version is available
        /// </summary>
        static public void CheckForUpdateIfNecessary()
        {
            try
            {
                bool shouldCheckForUpdate = true;

                if (lastCheckTimestamp == null)
                {
                    // get last check timestamp from registry and keep it in memory
                    lastCheckTimestamp = GetLastCheckTimestampFromRegistry();
                }

                // determine if we should make an update check based on the cached in memory last update check timestamp
                shouldCheckForUpdate = ShouldCheckForUpdate(lastCheckTimestamp);
                if (shouldCheckForUpdate)
                {
                    // if the in-memory last update timecheck indicates we should make a check (up to once a day), refresh the last check timestamp
                    // from the registry and check again.  This prevents multiple instances of VS running on one machine from making multiple
                    // update checks.
                    lastCheckTimestamp = GetLastCheckTimestampFromRegistry();
                    // see if we should still make an update check based on the last check timestamp we just refreshed from the registry
                    shouldCheckForUpdate = ShouldCheckForUpdate(lastCheckTimestamp);
                }

                if (shouldCheckForUpdate)
                {
                    using (RegistryKey regKey = Registry.LocalMachine.CreateSubKey(RegKeyName))
                    {
                        // set now as the last time we did an update check
                        lastCheckTimestamp = DateTime.Now.ToString();
                        regKey.SetValue(RegValueLastUpdateCheck, lastCheckTimestamp);

                        // start an async download from the URL that contains the XML for the product update data
                        WebClient webClient = new WebClient();
                        webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DownloadDataCompleted);
                        string fullUrl = UpdateXmlUrl + "?CRC=" + CRC + "&v=" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        webClient.DownloadDataAsync(new Uri(fullUrl));
                    }
                }
            }
            catch 
            {
                // paranoid catch in case anything goes wrong (parsing of registry values, creation of web client).  Just fail silently
                // and let autoupdate not work.  Not worth pestering the user over.
            }            
        }

        static private string GetLastCheckTimestampFromRegistry()
        {
            string lastCheckTimestamp = null;
            using (RegistryKey regKey = Registry.LocalMachine.CreateSubKey(RegKeyName))
            {
                // Look in the registry to see when the last time we checked for an update was
                lastCheckTimestamp = (string)regKey.GetValue(RegValueLastUpdateCheck);

                // get last known online current version and download URL from the registry
                LatestVersion = (string)regKey.GetValue(RegValueLatestVersion);
                DownloadUrl = (string)regKey.GetValue(RegValueDownloadUrl);
                CRC = (string)regKey.GetValue(RegValueCRC);

                if (String.IsNullOrEmpty(CRC))
                {
                    Random random = new Random();
                    int value = random.Next();
                    CRC = Convert.ToBase64String(BitConverter.GetBytes(value));
                    // standard URL encoding for Base64 -- see http://en.wikipedia.org/wiki/Base64
                    CRC = CRC.Replace('+', '-').Replace('/', '_').Replace("=", "");
                    regKey.SetValue(RegValueCRC, CRC);
                }
            }
            return lastCheckTimestamp;
        }

        static private bool ShouldCheckForUpdate(string timestamp)
        {
            bool shouldCheckForUpdate = true;
            if (!string.IsNullOrEmpty(timestamp))
            {
                try
                {
                    DateTime dateTimeLastCheck = DateTime.Parse(timestamp);
                    if (DateTime.Now.Day == dateTimeLastCheck.Day && DateTime.Now.Month == dateTimeLastCheck.Month)
                    {
                        shouldCheckForUpdate = false;
                    }
                }
                catch (FormatException)
                {
                    // catch error if there's bad data in the registry
                }
            }
            return shouldCheckForUpdate;
        }

        /// <summary>
        /// Called when product update data is downloaded
        /// </summary>
        static void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
                return;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                byte[] data = e.Result;
                int start = 0;
                int length = data.Length;       

                // skip past the UTF8 byte order marker (BOM) if it's there
                if ((data.Length >= 3) && (data[0] == 0xEF) && (data[1] == 0xBB) && (data[2] == 0xBF))
                {
                    start += 3;
                    length -= 3;
                }

                string xmlText = System.Text.UTF8Encoding.Default.GetString(data, start, length);
                xmlDocument.LoadXml(xmlText);
                XmlElement element = xmlDocument.SelectSingleNode("update/product[@name='PhatStudio']") as XmlElement;
                if (element != null)
                {
                    // get current version # & download URL
                    LatestVersion = element.Attributes["currentversion"].Value;
                    DownloadUrl = element.Attributes["downloadurl"].Value;

                    // store these values in the registry
                    using (RegistryKey regKey = Registry.LocalMachine.CreateSubKey(RegKeyName))
                    {
                        regKey.SetValue(RegValueLatestVersion, LatestVersion);
                        regKey.SetValue(RegValueDownloadUrl, DownloadUrl);
                    }

                    // UI will ask us for current online version # and compare compiled-in version # to that and respond appropriately
                }
            }
            catch 
            { 
                // paranoid catch for bogus XML data, etc
            }
        }
    }
}