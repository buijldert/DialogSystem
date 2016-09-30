using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetOptionButtons : MonoBehaviour {

    //set buttons to be appearing/disappearing
    [SerializeField]private Button[] _optionsButtons;

    void OnEnable()
    {
        MessageLoader.OnControlOptionsButtonsVisibility += HideOptionsButtons;
        MessageLoader.OnShowAndSetOptionsButtons += ShowOptionsButtonsWithText;
    }

    //show the buttons and send the text
    void ShowOptionsButtonsWithText(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            _optionsButtons[i].gameObject.SetActive(true);
            _optionsButtons[i].gameObject.GetComponentInChildren<Text>().text = options[i];
        }
    }

    //hide the buttons
    void HideOptionsButtons()
    {
        for (int i = 0; i < _optionsButtons.Length; i++)
        {
            _optionsButtons[i].gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        MessageLoader.OnControlOptionsButtonsVisibility -= HideOptionsButtons;
        MessageLoader.OnShowAndSetOptionsButtons -= ShowOptionsButtonsWithText;
    }
}
