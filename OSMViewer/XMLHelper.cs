/*****************************************************************************
 * 
 * CONFIDENTIAL TO DIGITAL ALCHEMY, INC.
 * __________________
 * 
 *  Copyright [2009] - [2017] Digital Alchemy, Incorporated 
 *  All Rights Reserved.
 * 
 * NOTICE:  All information contained herein is, and remains the property of 
 * Digital Alchemy, Incorporated and its suppliers, if any.  The intellectual 
 * and technical concepts contained herein are proprietary to Digital Alchemy, 
 * Incorporated and its suppliers and may be covered by U.S. and Foreign 
 * Patents, patents in process, and are protected by trade secret or 
 * copyright law.
 * Dissemination of this information, or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from Digital Alchemy Incorporated.
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net;

namespace Simergy.Common.Helpers
{
    public class XMLHelper
    {
        private static string GetXMLData(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return xmlString;
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }

        public static XmlDocument GetXMLDocumentFromFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetXMLData(fileName));
            //doc.LoadXml(fileName);
            return doc;
        }

        public static XmlDocument LoadXMLDocument(string fileURI)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileURI);
            }
            catch (Exception ex)
            {
                doc = null;
            }

            return doc;
        }

        /// <summary>
        ///  Get Data in xml format by url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static XmlDocument GetXmlDataFromUrl(string url)
        {
            //creating XML document
            var xmlDoc = new XmlDocument();
            try
            {
                //requesting the particular web page
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                //geting the response from the request url
                var response = (HttpWebResponse)httpRequest.GetResponse();

                //create a stream to hold the contents of the response (in this case it is the contents of the XML file
                using (var receiveStream = response.GetResponseStream())
                {
                    //load the file from the stream
                    xmlDoc.Load(receiveStream);

                    //close the stream
                    receiveStream.Close();
                }
            }
            catch (Exception)
            {                
                xmlDoc = null;
            }

            return xmlDoc;
        }

        public static XmlDocument GetXMLDocumentFromString(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            return doc;
        }

        public static IEnumerable<T> Convert<T>(System.Collections.IEnumerable enumerable)
        {
            foreach (object current in enumerable)
            {
                yield return (T)current;
            }
        }

        public static void CopyNodesToRoot(XmlDocument destinationDOM, XmlNodeList nodesToCopy)
        {
            XmlNode[] nodes;
            nodes = (new List<XmlNode>(XMLHelper.Convert<XmlNode>(nodesToCopy))).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                //Import node to main document and append to child
                destinationDOM.ChildNodes[0].AppendChild(destinationDOM.ImportNode(nodes[i], true));
            }

        }

        public static void CopyNode(XmlDocument destinationDOM, XmlNode nodeToCopy)
        {
            //Import node to main document and append to child
            XmlNode nodeToMove = destinationDOM.ImportNode(nodeToCopy, true);
            destinationDOM.AppendChild(nodeToMove);
        }

        public static T Deserialize<T>(string xml)
        {
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((T)(serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static void ToXML(string fileName, object obj)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize(obj);
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        public static string Serialize(Object obj)
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(obj.GetType());
            try
            {
                memoryStream = new System.IO.MemoryStream();
                serializer.Serialize(memoryStream, obj);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        //This method has been added to check whether the file is valid SimModel file or not
        public static bool IsValidSimModelFile(string xmlFilePath)
        {

            try
            {
                bool hasSimModelTag = false;
                XDocument po = XDocument.Load(xmlFilePath);
                XElement rootElement = po.Root;
                if (rootElement != null)
                {
                    hasSimModelTag = rootElement.Name.LocalName.ToLower() == "simmodel";
                }
                return hasSimModelTag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
