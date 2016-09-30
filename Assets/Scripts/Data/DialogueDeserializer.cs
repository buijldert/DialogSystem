using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogues")]
public class DialogueDeserializer
{
    //put all messages in one list
    [XmlArray("messages")]
    [XmlArrayItem("message")]
    public List<Message> messages = new List<Message>();

    //Function to load the file and deserialize the xml file
    public static DialogueDeserializer Load(TextAsset xmlFile)
    {
        TextAsset _xml = xmlFile;

        if (_xml == null)
        {
            Debug.LogError("No XML file found!");
        }
        
        //create XmlSerializer
        XmlSerializer serializer = new XmlSerializer(typeof(DialogueDeserializer));

        //create StringReader
        StringReader reader = new StringReader(_xml.text);

        //store and deserialize messages into a dialogues
        DialogueDeserializer dialogues = serializer.Deserialize(reader) as DialogueDeserializer;

        //close reader
        reader.Close();

        //return messages
        return dialogues;
    }
}
