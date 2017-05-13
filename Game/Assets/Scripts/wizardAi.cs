﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardAi : MonoBehaviour {
    public StateManager state;
    public float timeToLerp;
    public Vector3 min;
    public Vector3 max;
    Vector3 randomPos;
    Animator anim;
    Collider col;
    public Camera cam;
	// Use this for initialization
	void Start () {
     //   min = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
      //  max = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        moving = true;
        anim = GetComponent<Animator>();
        randomPos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
        col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(moving == true)
        {
            moveToPosition(randomPos);
        }
	}
   public void killed()
    {
        transform.tag = "Dead";
        anim.SetBool("isAlive", false);
        col.enabled = false;
    }
    bool started = false;
    bool moving;
    Vector3 startPosition;
    float percentComplete;
    float startTime;
    void moveToPosition(Vector3 position)
    {
        if(started == false)
        {

             startPosition = transform.position;
             startTime = Time.time;
            anim.SetBool("isMoving", true);
            started = true;
        }
        float timeSinceStart = Time.time - startTime;
       float percentComplete = timeSinceStart / timeToLerp;
        transform.position = Vector3.Lerp(startPosition, position, percentComplete);

        if (percentComplete > 1.0f)
        {
            anim.SetBool("isMoving", false);
            moving = false;
        }

        

    }
    void OnParticleCollision()
    {
        killed();
    }

}
