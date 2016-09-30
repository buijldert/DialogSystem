using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Message
{
    [XmlAttribute("id")]
    public int id;

    [XmlElement("source")]
    public string Source { get; set; }
    //public string source;

    [XmlElement("text")]
    public string Text { get; set; }
    
    [XmlArray("options")]
    [XmlArrayItem("option")]
    public string[] Options { get; set; }

    [XmlArray("destinations")]
    [XmlArrayItem("destination")]
    public int[] Destinations { get; set; }
}
    
