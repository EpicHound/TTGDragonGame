using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
    State currentState;
    public ScoreManager Score;
    public Text debugTextPressure;
    public Text ScoreText;
    public int CurrentScore = 0;
    public dragonAi ai;
    float maxBreathPressure  = 0.6f;
    public GameObject wizard;
    public GameObject redWizard;
    float maxBreathLength = 5f;
    // public Fizzyo.BreathRecogniser breath = new Fizzyo.BreathRecogniser(PlayerPrefs.GetFloat("Max Fizzyo Pressure"), PlayerPrefs.GetFloat("Max Fizzyo Length"));
    public Fizzyo.BreathRecogniser breath;
    public Fizzyo.BreathRecogniser lastBreath;
    // Use this for initialization
    void Start () {
        float maxTime = PlayerPrefs.GetFloat("Max Fizzyo Time");
        float maxPressure = PlayerPrefs.GetFloat("Max Fizzyo Pressure");
        breath = new Fizzyo.BreathRecogniser(maxPressure, maxBreathLength);
        currentState = State.Idle;
        breath.ExhalationComplete += Breath_ExhalationComplete;
	}
    public GameObject great;
    private void Breath_ExhalationComplete(object sender, Fizzyo.ExhalationCompleteEventArgs e)
    {
        ai.breathComplete = true;
        if (e.IsBreathGood)
        {
            Score.UpdateScore();
            great.SetActive(true);
        }
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
                makeEnemies();
                break;
        }
        debugTextPressure.text = Fizzyo.FizzyoDevice.Instance().Pressure().ToString();
        breath.AddSample(Time.deltaTime, Fizzyo.FizzyoDevice.Instance().Pressure());

    }
    void makeEnemies()
    {
        int number = Random.Range(3, 8);
        for (int i = 0; i <= number; i++)
        {
            Instantiate(wizard);
        }
        int num = Random.Range(0, 2);
        for (int i = 0; i <= num; i++)
        {
            Instantiate(redWizard);
        }
        currentState = State.Aiming;  
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
