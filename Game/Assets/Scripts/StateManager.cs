using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
    State currentState;
    public Text debugTextPressure;
    public dragonAi ai;
    float maxBreathPressure  = 0.6f;
    float maxBreathLength = 5f;
    // public Fizzyo.BreathRecogniser breath = new Fizzyo.BreathRecogniser(PlayerPrefs.GetFloat("Max Fizzyo Pressure"), PlayerPrefs.GetFloat("Max Fizzyo Length"));
    public Fizzyo.BreathRecogniser breath = new Fizzyo.BreathRecogniser(0.6f, 5);
    public Fizzyo.BreathRecogniser lastBreath;
    // Use this for initialization
    void Start () {
        
        currentState = State.Idle;
        breath.ExhalationComplete += Breath_ExhalationComplete;
	}

    private void Breath_ExhalationComplete(object sender, Fizzyo.ExhalationCompleteEventArgs e)
    {
        ai.breathComplete = true;
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
            case State.Moving:
                break;
        }
        debugTextPressure.text = Fizzyo.FizzyoDevice.Instance().Pressure().ToString();
        breath.AddSample(Time.deltaTime, Fizzyo.FizzyoDevice.Instance().Pressure());

    }

    public void Shooting()
    {
       
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
        Shooting,
        Moving
    }

}
