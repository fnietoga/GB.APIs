using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;
using GB.OrdersAPI.Models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GB.OrdersAPI.Repositories
{
    public class ServiceBusRepository
    {

        public void Send(CreateOrder order)
        {
            string xmlObject = GetXMLFromObject(order);

            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string queueName = "NewOrders";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(xmlObject);

            client.Send(message);
        }

        private string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }
}

