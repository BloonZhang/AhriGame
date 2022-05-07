using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{

    // test gameobjects
    /*
    public TextMeshProUGUI textBox1;
    private int counter1 = 0;
    public TextMeshProUGUI textBox2;
    private int counter2 = 0;
    public TextMeshProUGUI textBox3;
    private int counter3 = 0;
    */

    // public GameObjects
    public AhriController ahri;

    // helper variables
    private int ahriCurrentLocation = 0;

    // settings variables
    private Vector3[] ahriPositions = 
        new Vector3[]
        {
            new Vector3(-5f, -1f, 0f),
            new Vector3(-2.5f, -1f, 0f),
            new Vector3(5f, -1f, 0f)
        };

    //////// Singleton shenanigans ////////
    private static SceneManager _instance;
    public static SceneManager Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    void Start()
    {
        MoveAhriToLocation(0);
    }

    // Methods called from InputManager
    public void MoveAhriToLocation(int location)
    {
        if (location > ahriPositions.Length)
        {
            Debug.Log("Invalid location in SceneManager.MoveAhriToLocation(int)");
            return;
        }
        ahri.MoveToPosition(ahriPositions[location]);
        ahriCurrentLocation = location;
    }
    public void PerformQAction()
    {
        switch (ahriCurrentLocation)
        {
            case 0: // desk
                ahri.Shake();
                JobManager.Instance.WorkOnResume();
                break;
            case 2: // mail
                ahri.Shake();
                JobManager.Instance.SendOutOne();
                break;
            default:
                break;
        }
    }
    public void PerformWAction()
    {
        switch (ahriCurrentLocation)
        {
            case 0: // desk
                ahri.Shake();
                JobManager.Instance.WorkOnCoverLetter();
                break;
            default:
                break;
        }
    }
    public void PerformEAction()
    {
        switch (ahriCurrentLocation)
        {
            case 0: // desk
                ahri.Dip();
                break;
            default:
                break;
        }
    }
    public void HeldEAction(float deltaTime)
    {
        switch (ahriCurrentLocation)
        {
            case 0: // desk
                break;
            default:
                break;
        }
    }
    public void ReleaseEAction()
    {
        switch (ahriCurrentLocation)
        {
            case 0: // desk
                ahri.Return();
                break;
            default:
                break;
        }
    }
}