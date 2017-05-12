using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    State currentState;
	// Use this for initialization
	void Start () {
        currentState = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public State GetState()
    {
        return currentState;
    }
    public enum State
    {
        Idle,
        Aiming,
        Shooting
    }

}
