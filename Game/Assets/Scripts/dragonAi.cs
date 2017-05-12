using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonAi : MonoBehaviour {
    // Use this for initialization
   public StateManager stateManager;
    public float angle = 90;
    public float desiredRotation;
    private Quaternion initialRotation;
    public float timeToLerp = 1f;
    //fizyo stuff
    public float maxFizzyoPressure = 0.5f;
    void Start () {
        //load our sensor calibration if already set
        if (PlayerPrefs.HasKey("Max Fizzyo Pressure"))
        {
            maxFizzyoPressure = PlayerPrefs.GetFloat("Max Fizzyo Pressure");
            Debug.Log("Set max fizzyo pressure val to: " + maxFizzyoPressure);
        }


        initialRotation = transform.rotation;
        desiredRotation = angle;
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        startPosition = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (stateManager.GetState())
        {
            case StateManager.State.Idle:
                startAim = true;
                break;
            case StateManager.State.Shooting:
                startAim = true;
                Shooting();
                break;
            case StateManager.State.Aiming:
                Aiming();
                break;
        }
	}

    private void FixedUpdate()
    {
        
      
    }
    Quaternion desiredRotQ;
    bool startAim = false;
    void Aiming()
    {   
        HeadRotate();      
    }
    void Shooting()
    {

    }
    float StartTime;
    Quaternion startPosition;
    void HeadRotate()
    {
        if(startAim == true)
        {
            startPosition = transform.rotation;
            StartTime = Time.time;
            desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
            startAim = false;
        }
        float timeSinceStart = Time.time - StartTime;
        float percentComplete = timeSinceStart / timeToLerp;
        transform.rotation = Quaternion.Lerp(startPosition, desiredRotQ, percentComplete);

        if (percentComplete > 1.0f)
        {
            startPosition = transform.rotation;
            StartTime = Time.time;
            desiredRotation = -1 * desiredRotation;
            desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        }
    }
    
}
