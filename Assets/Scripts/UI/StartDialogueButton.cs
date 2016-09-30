using UnityEngine;
using System.Collections;

public class StartDialogueButton : MonoBehaviour {

    //event for starting the dialogue
    public delegate void StartDialogueAction(int id);
    public static event StartDialogueAction OnStartDialogue;

    //press the button to start the dialogue
    public void StartDialogue()
    {
        if(OnStartDialogue != null)
        {
            OnStartDialogue(1);
        }
    }
}
