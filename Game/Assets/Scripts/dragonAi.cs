﻿using System.Collections;
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
                fireEffect.gameObject.SetActive(true);
                Shooting();
                break;
            case StateManager.State.Aiming:
                Aiming();
                break;
        }
	}
    Quaternion desiredRotQ;
    bool startAim = false;
    void Aiming()
    {   
        HeadRotate();      
    }
    public ParticleSystem fireEffect;
   public  float maxFireLength;
    bool started = false;
    List<GameObject> enemies = new List<GameObject>();
    void Shooting()
    {
        float pressure = Fizzyo.FizzyoDevice.Instance().Pressure();
        if (enemies == null)
        {
         enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }
        else
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemyIsHit(enemies[i], pressure))
                {
                    //kill
                }
                else
                {
                    enemies.RemoveAt(i);
                    i -= 1;
                }
            }
        }
       
        
        if(pressure> maxFizzyoPressure / 2)
        {
            started = true;
        }
        fireEffect.startLifetime = (pressure / maxFizzyoPressure) * maxFireLength;

        

        if(started == true && pressure < maxFizzyoPressure / 3)
        {
            fireEffect.gameObject.SetActive(false);
            stateManager.changeState(StateManager.State.Aiming);
            startAim = true;
            started = false;
        }
    }
    

    bool enemyIsHit(GameObject objToSee, float CloseDistanceRange)
    {
        RaycastHit hit;
        var rayDirection = objToSee.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) < 20 && (Vector3.Distance(transform.position, objToSee.transform.position) <= CloseDistanceRange))
        {
            //Debug.Log("close");
            return true;
        }
        else
        {
            return false;
        }
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
