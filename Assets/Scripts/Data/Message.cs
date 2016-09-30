using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Message
{
    //store message id
    [XmlAttribute("id")]
    public int id { get; set; }

    //store source of the message
    [XmlElement("source")]
    public string Source { get; set; }

    //store text of the message
    [XmlElement("text")]
    public string Text { get; set; }
    
    //store options for buttons
    [XmlArray("options")]
    [XmlArrayItem("option")]
    public string[] Options { get; set; }

    //store the options destinations
    [XmlArray("destinations")]
    [XmlArrayItem("destination")]
    public int[] Destinations { get; set; }
}
    
