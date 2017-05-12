using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
    State currentState;
    public Text debugTextPressure;
    // Use this for initialization
    void Start () {
        currentState = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case State.Idle:
                if (Input.GetButtonDown("Fire1"))
                {
                    currentState = State.Aiming;
                }
                break;
            case State.Shooting:
                break;
            case State.Aiming:
                if (Input.GetButtonDown("Fire1"))
                {
                    currentState = State.Shooting;
                }
                break;
        }
        debugTextPressure.text = Fizzyo.FizzyoDevice.Instance().Pressure().ToString();

    }

    public State GetState()
    {
        return currentState;
    }
    public void changeState(State newState)
    {
        currentState = newState;
    } 
    public enum State
    {
        Idle,
        Aiming,
        Shooting
    }

}
