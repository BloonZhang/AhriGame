using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{

    // events
    public event Action<Application> PhoneInterviewReady;
    public event Action<Application> OnlineInterviewReady;

    // public variables
    public List<Application> listOfApplications = new List<Application>();
    public int SubmittedApplicationCounter = 0;
    // settings variables
    private float timeUntilPhoneMin = 1f;
    private float timeUntilPhoneMax = 1.5f;
    private float timeUntilOnlineMin = 20f;
    private float timeUntilOnlineMax = 30f;
    private int ApplicationsForGameOver = 35;
    private List<string> PotentialCompanyNames = new List<string>()
    {
        "Stallmart, Inc.",
        "Scamazon, Inc.",
        "Pear, Inc.",
        "CS Health Corporation.",
        "FlexonMobil, Inc.",
        "McKennen Corporation",
        "Goggle, Inc.",
        "AT || T, Inc.",
        "Bored Motor Company",
        "FedGoNext Express Corporation",
        "ChevSpawn-Kill Gas",
        "Microhard Technologies",
        "Chase Singed Banking",
        "GPMorgan, Inc.",
        "Voligreens Pharmaceuticals",
        "Verizoning Communciation, Inc.",
        "The Throwger Company",
        "Neekroger Retail",
        "Fannie MIA",
        "Bank of Runeterra Corporation",
        "The Nexus Depot",
        "Fiddlesticks 66",
        "Chromacast Corporation",
        "Anathema, Inc.",
        "Jarvan & Jarvan",
        "State Jungle Insurance",
        "INTel Corporation",
        "The Goldman Stacks Group, Inc.",
        "Pfizzer, Inc.",
        "Poppy Air Lines",
        "Noxus Life Insurance Company",
        "Zeri Energy Company",
        "(top) Gap, Inc.",
        "Foxfire News Corporation",
        "OMWayfair, Inc.",
        "ActiVisionScore, Inc.",
        "JayceBook, Inc.",
        "EnterpRyze Products",
        "Rell Technologies",
        "Miss Fortune 500",
        "blOOMberg L.P.",
        "Aurelion Sol-utions",
        "The Yordlémon Company",
        "Twitch the Plague Rat.tv",
        "Tristcord, Inc.",
        "Pantheon Bakery",
        "Adobe Hexflash, Inc."
    };
    // helper variables
    private List<string> RemainingCompanyNames = new List<string>();

    //////// Singleton shenanigans ////////
    private static ApplicationManager _instance;
    public static ApplicationManager Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // public methods
    public void CreateApplication()
    {
        string companyName;
        // If it's time for the game to end
        if (SubmittedApplicationCounter == ApplicationsForGameOver) { companyName = "Riot Games, Inc."; }
        // Otherwise, create a random name
        else 
        {
            // if List somehow doesn't exist or if it's become empty
            if (RemainingCompanyNames == null || RemainingCompanyNames.Count == 0) { CreateDeepCopyOfCompanyNames(); }
            int random = UnityEngine.Random.Range(0, RemainingCompanyNames.Count - 1);
            companyName = RemainingCompanyNames[random];
            RemainingCompanyNames.RemoveAt(random);
        }
        Application newApplication = new Application(companyName);
        listOfApplications.Add(newApplication); SubmittedApplicationCounter++;
        SendForPhoneInterview(newApplication);
    }
    public void SendForPhoneInterview(Application application)
    {
        StartCoroutine(WaitForPhoneCoroutine(application));
    }
    public void SendForOnlineInterview(Application application)
    {
        StartCoroutine(WaitForOnlineCoroutine(application));
    }

    // private methods
    private void BroadcastPhoneInterviewReady(Application application)
    {
        if (PhoneInterviewReady != null)
        {
            PhoneInterviewReady.Invoke(application);
        }
    }
    private void BroadcastOnlineInterviewReady(Application application)
    {
        if (OnlineInterviewReady != null)
        {
            OnlineInterviewReady.Invoke(application);
        }
    }

    // helper methods
    private void CreateDeepCopyOfCompanyNames()
    {
        RemainingCompanyNames = new List<string>();
        foreach(string str in PotentialCompanyNames)
        {
            RemainingCompanyNames.Add(str);
        }
    }

    // Coroutines
    IEnumerator WaitForPhoneCoroutine(Application application)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(timeUntilPhoneMin, timeUntilPhoneMax));
        application.CompletePhoneInterview(); BroadcastPhoneInterviewReady(application);
    }
    IEnumerator WaitForOnlineCoroutine(Application application)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(timeUntilOnlineMin, timeUntilOnlineMax));
        application.CompleteOnlineInterview(); BroadcastOnlineInterviewReady(application);
    }
}
