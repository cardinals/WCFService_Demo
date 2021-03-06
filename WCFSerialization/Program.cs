﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WCFSerialization
{
    class Program
    {
        static string _basePath = @"E:\gitRepo\WCFService_Demo\WCFSerialization\";

        static void Main(string[] args)
        {
            //SerializeViaDataContractSerializer();
            //DeserializeViaDataContractSerializer();

            SerializeViaXMLSerializer();
            DeserializeViaXMLSerializer();
        }

        static void SerializeViaDataContractSerializer()
        {
            DataContractProduct product = new DataContractProduct(Guid.NewGuid(), "Dell PC", "Xiamen FuJian", 4500);
            DataContractOrder order = new DataContractOrder(Guid.NewGuid(), DateTime.Today, product, 300);
            string fileName = _basePath + "Order.DataContractSerializer.xml";
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(DataContractOrder));
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
                {
                    serializer.WriteObject(writer, order);
                }
            }
            Process.Start(fileName);
        }

        static void DeserializeViaDataContractSerializer()
        {
            string fileName = _basePath + "Order.DataContractSerializer.xml";
            DataContractOrder order;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(DataContractOrder));

                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    order = serializer.ReadObject(reader) as DataContractOrder;
                }
            }

            Console.WriteLine(order);
            Console.Read();
        }

        static void SerializeViaXMLSerializer()
        {
            XMLProduct product = new XMLProduct(Guid.NewGuid(), "Dell PC", "Xiamen FuJian", 4500);
            XMLOrder order = new XMLOrder(Guid.NewGuid(), DateTime.Today, product, 300);
            string fileName = _basePath + "Order.XmlSerializer.xml";
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLOrder));
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
                {
                    serializer.Serialize(writer, order);
                }
            }
            Process.Start(fileName);
        }

        static void DeserializeViaXMLSerializer()
        {
            string fileName = _basePath + "Order.XmlSerializer.xml";
            XMLOrder order;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLOrder), "http://WCFService/WCFSerialization");
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    order = serializer.Deserialize(reader) as XMLOrder;
                }
            }

            Console.WriteLine(order);
            Console.Read();
        }
    }
}