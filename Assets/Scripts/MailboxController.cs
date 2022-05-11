using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxController : MonoBehaviour
{

    // public GameObjects
    public GameObject IncomingMailBubble;

    // private variables
    private bool incomingMail = false;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        IncomingMailBubble.SetActive(incomingMail);
    }

    // public methods
    public void Reset()
    {
        incomingMail = false;
        IncomingMailBubble.SetActive(false);
    }
    public void SetIncomingMail(bool setting) { incomingMail = setting; }

}
