using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application
{
    // static variables
    private static List<string> PotentialCompanyNames = new List<string>()
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
    private static List<string> RemainingCompanyNames = new List<string>();
    public static int SubmittedApplicationCounter = 0;
    private static int ApplicationsForGameOver = 35;

    // constructors
    public Application()
    {
        // If it's time for the game to end
        if (SubmittedApplicationCounter == ApplicationsForGameOver) { companyName = "Riot Games, Inc."; }
        // Otherwise, create a random name
        else 
        {
            // if List somehow doesn't exist or if it's become empty
            if (RemainingCompanyNames == null || RemainingCompanyNames.Count == 0) { CreateDeepCopyOfCompanyNames(); }
            int random = Random.Range(0, RemainingCompanyNames.Count - 1);
            companyName = RemainingCompanyNames[random];
            RemainingCompanyNames.RemoveAt(random);
        }
        resumeCompleted = false;
        phoneCompleted = false;
        onlineCompleted = false;
        applicationFinished = false;
        SubmittedApplicationCounter++;
        Debug.Log(companyName);
    }

    // public variables
    public string companyName;
    public bool resumeCompleted;
    public bool phoneCompleted;
    public bool onlineCompleted;
    public bool applicationFinished;

    // helper methods
    private void CreateDeepCopyOfCompanyNames()
    {
        RemainingCompanyNames = new List<string>();
        foreach(string str in PotentialCompanyNames)
        {
            RemainingCompanyNames.Add(str);
        }
    }

}
