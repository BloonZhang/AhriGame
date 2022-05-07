using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // helper variables
    private char inputLock = ' '; // TODO: is there a better way to handle this?
    private float timer;

    //////// Singleton shenanigans ////////
    private static InputManager _instance;
    public static InputManager Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Holds
        if (inputLock == 'e' && Input.GetKey("e")) { InputEHeld(); }

        // Key ups
        // Note: this is before key downs, so if player releases and presses key in the same frame, it will work
        if (Input.GetKeyUp("1")) { if (inputLock == '1') { inputLock = ' '; } }
        if (Input.GetKeyUp("2")) { if (inputLock == '2') { inputLock = ' '; } }
        if (Input.GetKeyUp("3")) { if (inputLock == '3') { inputLock = ' '; } }
        if (Input.GetKeyUp("q")) { if (inputLock == 'q') { inputLock = ' '; } }
        if (Input.GetKeyUp("w")) { if (inputLock == 'w') { inputLock = ' '; } }
        if (Input.GetKeyUp("e")) { if (inputLock == 'e') { InputEUp(); inputLock = ' '; } }

        // Key downs
        // Note: elseif logic to prevent multiple inputs from being counted in the same frame
        if (inputLock == ' ')
        {
            if (Input.GetKeyDown("1")) { Input1Down(); inputLock = '1'; }
            else if (Input.GetKeyDown("2")) { Input2Down(); inputLock = '2'; }
            else if (Input.GetKeyDown("3")) { Input3Down(); inputLock = '3'; }
            else if (Input.GetKeyDown("q")) { InputQDown(); inputLock = 'q'; }
            else if (Input.GetKeyDown("w")) { InputWDown(); inputLock = 'w'; }
            else if (Input.GetKeyDown("e")) { InputEDown(); inputLock = 'e'; }
        }

    }

    // input methods
    void Input1Down()
    {
        SceneManager.Instance.MoveAhriToLocation(0);
    }
    void Input2Down()
    {
        SceneManager.Instance.MoveAhriToLocation(1);
    }
    void Input3Down()
    {
        SceneManager.Instance.MoveAhriToLocation(2);
    }
    void InputQDown()
    {
        SceneManager.Instance.PerformQAction();
    }
    void InputWDown()
    {
        SceneManager.Instance.PerformWAction(); 
    }
    void InputEDown()
    {
        SceneManager.Instance.PerformEAction();
    }
    void InputEHeld()
    {
        SceneManager.Instance.HeldEAction(Time.deltaTime);
    }
    void InputEUp()
    {
        SceneManager.Instance.ReleaseEAction();
    }
}
