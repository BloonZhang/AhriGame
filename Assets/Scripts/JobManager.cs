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
    public TelephoneController online;
    public MailboxController mailbox;
    
    // public variables and fields
    //public int CompletedResumes { get { return completedResumes; } }
    //public int CompletedCoverLetters { get { return completedCoverLetters; } }

    // private variables
    private int completedResumes = 0;
    private int completedCoverLetters = 0;
    private Queue<Application> phoneQueue = new Queue<Application>();
    private Queue<Application> onlineQueue = new Queue<Application>();
    private Queue<Application> responseQueue = new Queue<Application>();

    // helper variables
    private int resumeCounter = 0;
    private int coverLetterCounter = 0;
    private float phoneCallTimer;
    private float onlineCallTimer;

    // settings variables
    private int resumeRequirement = 5;
    private int coverLetterRequirement = 7;
    private float timePerPhoneCall = 3f;
    private float timePerOnlineCall = 5f;


    //////// Singleton shenanigans ////////
    private static JobManager _instance;
    public static JobManager Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    // Unity methods
    void OnEnable()
    {
        ApplicationManager.Instance.PhoneInterviewReadyEvent += AddApplicationToPhoneQueue;
        ApplicationManager.Instance.OnlineInterviewReadyEvent += AddApplicationToOnlineQueue;
        ApplicationManager.Instance.ApplicationFinishedEvent += AddApplcationToResponseQueue;
    }
    void OnDisable()
    {
        ApplicationManager.Instance.PhoneInterviewReadyEvent -= AddApplicationToPhoneQueue;
        ApplicationManager.Instance.OnlineInterviewReadyEvent -= AddApplicationToOnlineQueue;
        ApplicationManager.Instance.ApplicationFinishedEvent -= AddApplcationToResponseQueue;
    }
    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }
    void Start()
    {
        phoneCallTimer = timePerPhoneCall; onlineCallTimer = timePerOnlineCall;
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
    public void PickUpPhone()
    {
        if (phoneQueue.Count == 0) { return; }
        phone.SetIncomingCall(false);
        phone.SetOngoingCall(true);
    }
    public void RespondToPhone(float time)
    {
        if (phoneQueue.Count == 0) { return; }
        if (phoneCallTimer > 0f) { phoneCallTimer -= time; }
        if (phoneCallTimer <= 0f)
        {
            phone.SetOngoingCall(false);
            phone.SetCompleteCall(true);
        }
    }
    public void HangUpPhone()
    {
        if (phoneQueue.Count == 0) { return; }
        // If current call is done
        if (phoneCallTimer <= 0) 
        { 
            phone.SetCompleteCall(false); 
            ApplicationManager.Instance.SendForOnlineInterview(phoneQueue.Dequeue());
            phone.SetIncomingCall(phoneQueue.Count > 0);
            phoneCallTimer = timePerPhoneCall;
        }
        // If current call is still ongoing
        else 
        { 
            phone.SetOngoingCall(false); phone.SetIncomingCall(true); 
        }
    }
    public void PickUpOnline()
    {
        if (onlineQueue.Count == 0) { return; }
        online.SetIncomingCall(false);
        online.SetOngoingCall(true);
    }
    public void RespondToOnline(float time)
    {
        if (onlineQueue.Count == 0) { return; }
        if (onlineCallTimer > 0f) { onlineCallTimer -= time; }
        if (onlineCallTimer <= 0f)
        {
            online.SetOngoingCall(false);
            online.SetCompleteCall(true);
        }
    }
    public void HangUpOnline()
    {
        if (onlineQueue.Count == 0) { return; }
        // If current call is done
        if (onlineCallTimer <= 0) 
        { 
            online.SetCompleteCall(false); 
            ApplicationManager.Instance.SendForReview(onlineQueue.Dequeue());
            online.SetIncomingCall(onlineQueue.Count > 0);
            onlineCallTimer = timePerOnlineCall;
        }
        // If current call is still ongoing
        else 
        { 
            online.SetOngoingCall(false); online.SetIncomingCall(true); 
        }
    }
    public void SendOutOne()
    {
        if (completedResumes < 1 || completedCoverLetters < 1) { return; }
        completedResumes -= 1; completedCoverLetters -= 1;
        ApplicationManager.Instance.SendForPhoneInterview(ApplicationManager.Instance.CreateApplication());
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
        phoneQueue.Enqueue(application);
        phone.SetIncomingCall(true);
    }
    private void AddApplicationToOnlineQueue(Application application)
    {
        onlineQueue.Enqueue(application);
        online.SetIncomingCall(true);
    }
    private void AddApplcationToResponseQueue(Application application)
    {
        responseQueue.Enqueue(application);
        mailbox.SetIncomingMail(true);
    }

    // helper methods
    private void UpdateText()
    {
        textBox1.text = string.Format("Resumes: {0}", completedResumes);
        textBox2.text = string.Format("Cover Letters: {0}", completedCoverLetters);
        textBox3.text = string.Format("Applications: {0}", ApplicationManager.Instance.SubmittedApplicationCounter);
    }

}
