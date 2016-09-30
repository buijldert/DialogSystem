using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {

    [SerializeField]private TextAsset _xmlFile;
    [SerializeField]private Text _sourceText;
    [SerializeField]private Text _messageText;
    [SerializeField]private Button[] _optionsButtons;
    private Message _currentMessage;
    private DialogueContainer _dc;
    private bool _destinationSent = false;

    public delegate void SendDestinationsAction(int[] destinations);
    public static event SendDestinationsAction OnSendDestinations;

    // Use this for initialization
    void OnEnable ()
    {
        _dc = DialogueContainer.Load(_xmlFile);
        StartDialogueButton.OnStartDialogue += LoadMessage;
        OptionButton.OnLoadNextMessage += LoadMessage;
        HideOptionsButtons();
    }

    public void LoadMessage(int id)
    {
        HideOptionsButtons();
        _destinationSent = false;
        foreach (Message message in _dc.messages)
        {
            if (message.id == id)
            {
                _currentMessage = message;
                if (OnSendDestinations != null && _destinationSent == false)
                {
                    OnSendDestinations(_currentMessage.Destinations);
                    _destinationSent = true;
                }

                _sourceText.text = message.Source;
                _messageText.text = message.Text;
                if(message.Options.Length > 0)
                {
                    for (int i = 0; i < message.Options.Length; i++)
                    {
                        _optionsButtons[i].gameObject.SetActive(true);
                        _optionsButtons[i].gameObject.GetComponentInChildren<Text>().text = message.Options[i];
                    }
                }
                else
                {
                    HideOptionsButtons();
                }
            }
        }
    }

    void HideOptionsButtons()
    {
        for (int i = 0; i < _optionsButtons.Length; i++)
        {
            _optionsButtons[i].gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        StartDialogueButton.OnStartDialogue -= LoadMessage;
        OptionButton.OnLoadNextMessage -= LoadMessage;
    }
}
