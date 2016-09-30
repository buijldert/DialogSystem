using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogues")]
public class DialogueContainer
{
    [XmlArray("messages")]
    [XmlArrayItem("message")]
    public List<Message> messages = new List<Message>();

    //Function to load the file
    public static DialogueContainer Load(TextAsset xmlFile)
    {
        TextAsset _xml = xmlFile;

        if (_xml == null)
        {
            Debug.LogError("No XML file found!");
        }
        
        XmlSerializer serializer = new XmlSerializer(typeof(DialogueContainer));

        StringReader reader = new StringReader(_xml.text);

        DialogueContainer dialogues = serializer.Deserialize(reader) as DialogueContainer;

        reader.Close();

        return dialogues;
    }
}
