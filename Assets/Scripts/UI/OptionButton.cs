using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour {

    [SerializeField]private int _destination;
    private int[] _destinations;

    public delegate void LoadNextMesssageAction(int destination);
    public static event LoadNextMesssageAction OnLoadNextMessage;

    void OnEnable()
    {
        DialogueLoader.OnSendDestinations += ReceiveDestinations;
    }

    public void StartResponse()
    {
        if(OnLoadNextMessage != null)
        {
            OnLoadNextMessage(_destinations[_destination]);
        }
    }

    private void ReceiveDestinations(int[] destinations)
    {
        _destinations = destinations;
    }

    void OnDisable()
    {
        DialogueLoader.OnSendDestinations += ReceiveDestinations;
    }
}
