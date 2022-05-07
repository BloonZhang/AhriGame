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

        // Note: elseif logic to prevent multiple inputs from being counted in the same frame
        // Key downs
        if (inputLock == ' ')
        {
            if (Input.GetKeyDown("1")) { Input1(); inputLock = '1'; }
            else if (Input.GetKeyDown("2")) { Input2(); inputLock = '2'; }
            else if (Input.GetKeyDown("3")) { Input3(); inputLock = '3'; }
            else if (Input.GetKeyDown("q")) { InputQ(); inputLock = 'q'; }
            else if (Input.GetKeyDown("w")) { InputW(); inputLock = 'w'; }
            else if (Input.GetKeyDown("e")) { InputE(); inputLock = 'e'; }
        }

        // Key ups
        if (Input.GetKeyUp("1")) { if (inputLock == '1') { inputLock = ' '; } }
        if (Input.GetKeyUp("2")) { if (inputLock == '2') { inputLock = ' '; } }
        if (Input.GetKeyUp("3")) { if (inputLock == '3') { inputLock = ' '; } }
        if (Input.GetKeyUp("q")) { if (inputLock == 'q') { inputLock = ' '; } }
        if (Input.GetKeyUp("w")) { if (inputLock == 'w') { inputLock = ' '; } }
        if (Input.GetKeyUp("e")) { if (inputLock == 'e') { inputLock = ' '; } }
    }

    // input methods
    void Input1()
    {
        SceneManager.Instance.MoveAhriToLocation(0);
    }
    void Input2()
    {
        SceneManager.Instance.MoveAhriToLocation(1);
    }
    void Input3()
    {
        SceneManager.Instance.MoveAhriToLocation(2);
    }
    void InputQ()
    {
        SceneManager.Instance.PerformQAction();
    }
    void InputW()
    {
        SceneManager.Instance.PerformWAction(); 
    }
    void InputE()
    {
        SceneManager.Instance.PerformEAction();
    }
    void InputEHeld()
    {
        SceneManager.Instance.HeldEAction(Time.deltaTime);
    }
}
