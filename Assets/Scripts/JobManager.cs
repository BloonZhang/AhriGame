using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JobManager : MonoBehaviour
{

    // test gameobjects
    public TextMeshProUGUI textBox1;
    public TextMeshProUGUI textBox2;
    public TextMeshProUGUI textBox3;

    // public GameObjects
    public TelephoneController phone;

    // public variables and fields
    //public int CompletedResumes { get { return completedResumes; } }
    //public int CompletedCoverLetters { get { return completedCoverLetters; } }

    // private variables
    private int completedResumes = 0;
    private int completedCoverLetters = 0;
    private List<Application> phoneQueue = new List<Application>();
    private List<Application> onlineQueue = new List<Application>();

    // helper variables
    private int resumeCounter = 0;
    private int coverLetterCounter = 0;

    // settings variables
    private int resumeRequirement = 5;
    private int coverLetterRequirement = 7;


    //////// Singleton shenanigans ////////
    private static JobManager _instance;
    public static JobManager Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    // Unity methods
    void OnEnable()
    {
        ApplicationManager.Instance.PhoneInterviewReady += AddApplicationToPhoneQueue;
        ApplicationManager.Instance.OnlineInterviewReady += AddApplicationToOnlineQueue;
    }
    void OnDisable()
    {
        ApplicationManager.Instance.PhoneInterviewReady -= AddApplicationToPhoneQueue;
        ApplicationManager.Instance.OnlineInterviewReady -= AddApplicationToOnlineQueue;
    }
    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // public methods
    public void WorkOnResume()
    {
        resumeCounter++;
        if (resumeCounter >= resumeRequirement)
        {
            completedResumes++;
            resumeCounter = 0;
            UpdateText();
        }
    }
    public void WorkOnCoverLetter()
    {
        coverLetterCounter++;
        if (coverLetterCounter >= coverLetterRequirement)
        {
            completedCoverLetters++;
            coverLetterCounter = 0;
            UpdateText();
        }
    }
    public void SendOutOne()
    {
        if (completedResumes < 1 || completedCoverLetters < 1) { return; }
        completedResumes -= 1; completedCoverLetters -= 1;
        ApplicationManager.Instance.CreateApplication();
        UpdateText();
    }
    /*
    public void SendOutAll()
    {
        int applications = System.Math.Min(completedResumes, completedCoverLetters);
        completedResumes -= applications; completedCoverLetters -= applications;
        for (int i = 1; i <= applications; i++)
        {
            listOfApplications.Add(new Application());
        }
        UpdateText();
    }
    */

    // private methods
    private void AddApplicationToPhoneQueue(Application application)
    {
        phoneQueue.Add(application);
        phone.SetIncomingCall(true);
    }
    private void AddApplicationToOnlineQueue(Application application)
    {
        onlineQueue.Add(application);
    }

    // helper methods
    private void UpdateText()
    {
        textBox1.text = string.Format("Resumes: {0}", completedResumes);
        textBox2.text = string.Format("Cover Letters: {0}", completedCoverLetters);
        textBox3.text = string.Format("Applications: {0}", ApplicationManager.Instance.SubmittedApplicationCounter);
    }

}
