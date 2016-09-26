using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;

public class Dialogues : MonoBehaviour {

    [SerializeField]private Text _dialogueText;

	// Use this for initialization
	void Start ()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Dialogues");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        XmlNodeList textArray = xmldoc.GetElementsByTagName("text");
        _dialogueText.text = textArray[0].InnerText;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}