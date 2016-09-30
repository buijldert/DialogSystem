using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageLoader : MonoBehaviour {

    //set the xml file to be read
    [SerializeField]private TextAsset _xmlFile;
    //set the text object for the source of the message
    [SerializeField]private Text _sourceText;
    //set the text object for the message
    [SerializeField]private Text _messageText;

    //current message that is being displayed
    private Message _currentMessage;
    //instance of DialogueDeserializer script
    private DialogueDeserializer _dd;
    //check if destinations have been sent
    private bool _destinationsSent = false;

    //event for sending the optionbuttons destinations
    public delegate void SendDestinationsAction(int[] destinations);
    public static event SendDestinationsAction OnSendDestinations;

    //event for controlling optionsbuttons visibility
    public delegate void ControlOptionsButtonsVisibilityAction();
    public static event ControlOptionsButtonsVisibilityAction OnControlOptionsButtonsVisibility;

    //event for setting options buttons text
    public delegate void ShowAndSetOptionsButtonsAction(string[] options);
    public static event ShowAndSetOptionsButtonsAction OnShowAndSetOptionsButtons;

    void OnEnable ()
    {
        //call load function in DialogueDeserializer
        _dd = DialogueDeserializer.Load(_xmlFile);
        StartDialogueButton.OnStartDialogue += LoadMessage;
        OptionButton.OnLoadNextMessage += LoadMessage;
        //hide the options buttons
        HideOptionsButtons();
    }

    //load the next message to be displayed
    public void LoadMessage(int id)
    {
        HideOptionsButtons();
        _destinationsSent = false;
        foreach (Message message in _dd.messages)
        {
            if (message.id == id)
            {
                _currentMessage = message;
                if (OnSendDestinations != null && _destinationsSent == false)
                {
                    OnSendDestinations(_currentMessage.Destinations);
                    _destinationsSent = true;
                }

                _sourceText.text = message.Source;
                _messageText.text = message.Text;
                if(message.Options.Length > 0)
                {
                    if(OnShowAndSetOptionsButtons != null)
                    {
                        OnShowAndSetOptionsButtons(message.Options);
                    }
                }
                else
                {
                    HideOptionsButtons();
                }
            }
        }
    }

    //hide the options buttons
    void HideOptionsButtons()
    {
        if (OnControlOptionsButtonsVisibility != null)
        {
            OnControlOptionsButtonsVisibility();
        }
    }

    void OnDisable()
    {
        StartDialogueButton.OnStartDialogue -= LoadMessage;
        OptionButton.OnLoadNextMessage -= LoadMessage;
    }
}
