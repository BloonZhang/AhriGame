using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    // public GameObjects
    public AhriController ahri;

    // settings variables
    private Vector3[] ahriPositions = 
        new Vector3[]
        {
            new Vector3(-5f, -1f, 0f),
            new Vector3(-2.5f, -1f, 0f),
            new Vector3(0f, -1f, 0f)
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

    public void MoveAhriToLocation(int location)
    {
        if (location > ahriPositions.Length)
        {
            Debug.Log("Invalid location in SceneManager.MoveAhriToLocation(int)");
            return;
        }
        ahri.MoveToPosition(ahriPositions[location]);
    }

}
