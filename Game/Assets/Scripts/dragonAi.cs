using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonAi : MonoBehaviour {
    // Use this for initialization
   public StateManager stateManager;
    public float smooth = 1f;
    public float angle = 90;
    public float desiredRotation;
    private Quaternion initialRotation;
    public float timeToLerp = 1f;
    void Start () {
        initialRotation = transform.rotation;
        desiredRotation = angle;
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);

    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void FixedUpdate()
    {
        
        Aiming();
    }
    Quaternion desiredRotQ;
    void Aiming()
    {
        HeadRotate();

        
           
        
        
        
        
    }
    float StartTime;
    void HeadRotate()
    {

        float timeSinceStart = Time.time - StartTime;
        float percentComplete = timeSinceStart / timeToLerp;

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, percentComplete);
        if (percentComplete > 1.0f)
        {
            StartTime = Time.time;
            desiredRotation = -1 * desiredRotation;
            desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotation);
        }
    }

}
