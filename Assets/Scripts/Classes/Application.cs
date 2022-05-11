using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application
{
    // constructors
    private Application() {}
    public Application(string name)
    {
        companyName = name;
        phoneCompleted = false;
        onlineCompleted = false;
        applicationFinished = false;
    }

    // public variables
    public string companyName;
    // private variables
    private bool phoneCompleted;
    private bool onlineCompleted;
    private bool applicationFinished;

    // public methods
    public void CompletePhoneInterview()
    {
        phoneCompleted = true;
    }
    public void CompleteOnlineInterview()
    {
        onlineCompleted = true;
    }
}
