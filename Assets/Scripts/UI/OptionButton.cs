using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour {

    //set the destination of the buttons
    [SerializeField]private int _destination;
    private int[] _destinations;
    
    //load message delegate
    public delegate void LoadNextMesssageAction(int destination);
    public static event LoadNextMesssageAction OnLoadNextMessage;

    void OnEnable()
    {
        MessageLoader.OnSendDestinations += ReceiveDestinations;
    }

    //when optionbutton is clicked load the response
    public void StartResponse()
    {
        if(OnLoadNextMessage != null)
        {
            OnLoadNextMessage(_destinations[_destination]);
        }
    }

    //receive the destinations from another script
    private void ReceiveDestinations(int[] destinations)
    {
        _destinations = destinations;
    }

    void OnDisable()
    {
        MessageLoader.OnSendDestinations += ReceiveDestinations;
    }
}
