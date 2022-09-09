using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using weather.model;

namespace weather.Util
{
    internal class XmlParser
    {
        public static List<Forecast> parseXmlToForecasts(String xmlResponse)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlResponse);
            XmlNodeList xmlNodes = xmlDoc.ChildNodes;
            xmlNodes = xmlNodes.Item(0).ChildNodes;
            xmlNodes = xmlNodes.Item(1).ChildNodes;
            List<Forecast> forecasts = new List<Forecast>();
            foreach (XmlNode node in xmlNodes)
            {
                if (node.Attributes["from"].Value.Equals(node.Attributes["to"].Value))
                {
                    Forecast forecast = new Forecast();
                    forecast.DateFrom = node.Attributes["from"].Value;
                    forecast.DateTo = node.Attributes["to"].Value;
                    XmlNodeList list = node.ChildNodes;
                    list = list.Item(0).ChildNodes;
                    foreach (XmlNode wetherNode in list)
                    {
                        if (wetherNode.Name.Equals("temperature"))
                        {
                            double temperature = double.Parse(wetherNode.Attributes["value"].Value.Replace(".", ","));
                            forecast.Temperature = (int)Math.Round(temperature, MidpointRounding.AwayFromZero);
                        }
                        if (wetherNode.Name.Equals("pressure"))
                        {
                            double pressure = double.Parse(wetherNode.Attributes["value"].Value.Replace(".", ","));
                            forecast.Pressure = (int)Math.Round(pressure, MidpointRounding.AwayFromZero);
                        }
                    }
                    forecasts.Add(forecast);
                }
            }
            return forecasts;
        }
    }
}
