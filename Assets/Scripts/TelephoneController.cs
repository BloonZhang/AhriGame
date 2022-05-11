using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneController : MonoBehaviour
{

    // public GameObjects
    public GameObject IncomingCallBubble;
    public GameObject OngoingCallBubbble;
    public GameObject CompleteCallBubble;

    // private variables
    private bool incomingCall = false;
    private bool ongoingCall = false;
    private bool completeCall = false;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        IncomingCallBubble.SetActive(incomingCall);
        OngoingCallBubbble.SetActive(ongoingCall);
        CompleteCallBubble.SetActive(completeCall);
    }

    // public methods
    public void Reset()
    {
        incomingCall = false; ongoingCall = false; completeCall = false;
        IncomingCallBubble.SetActive(false);
        OngoingCallBubbble.SetActive(false);
        CompleteCallBubble.SetActive(false);
    }
    public void SetIncomingCall(bool setting) { incomingCall = setting; }
    public void SetOngoingCall(bool setting) { ongoingCall = setting; }
    public void SetCompleteCall(bool setting) { completeCall = setting; }

}
