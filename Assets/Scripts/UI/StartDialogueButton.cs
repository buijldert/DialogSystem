using UnityEngine;
using System.Collections;

public class StartDialogueButton : MonoBehaviour {

    public delegate void StartDialogueAction(int id);
    public static event StartDialogueAction OnStartDialogue;

    public void StartDialogue()
    {
        if(OnStartDialogue != null)
        {
            OnStartDialogue(1);
        }
    }
}
