using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Configuration;

namespace storeAssist
{
    public sealed class xmlHelper
    {     
        public static string FullAppPath
        {
            get { return Assembly.GetExecutingAssembly().Location + ".config"; }
        }

        public xmlHelper() { }

        public static string ReadSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void WriteSetting(string key, string value)
        {         
            XmlDocument doc = loadConfigDocument();

            XmlNode node = doc.SelectSingleNode("//connectionStrings");

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {             
               XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@name='{0}']", key));

                if (elem != null)
                {
                    elem.SetAttribute("connectionString", value);
                }
                else
                {                 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("name", key);
                    elem.SetAttribute("connectionString", value);
                    elem.SetAttribute("providerName", "System.Data.SqlClient");  
                    node.AppendChild(elem);
                }
                doc.Save(getConfigFilePath());
            }
            catch
            {
                throw;
            }
        }

        public static void RemoveSetting(string key)
        {           
            XmlDocument doc = loadConfigDocument();

            XmlNode node = doc.SelectSingleNode("//connectionStrings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                else
                {                 
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@name='{0}']", key)));
                    doc.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
            }
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private static string getConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }
    }
}
