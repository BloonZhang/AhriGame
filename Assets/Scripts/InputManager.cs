using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

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
        if (Input.GetKeyDown("1")) { Input1(); }
        if (Input.GetKeyDown("2")) { Input2(); }
        if (Input.GetKeyDown("3")) { Input3(); }
        if (Input.GetKeyDown("q")) { InputQ(); }
        if (Input.GetKeyDown("w")) { InputW(); }
        if (Input.GetKeyDown("e")) { InputE(); }
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
}
