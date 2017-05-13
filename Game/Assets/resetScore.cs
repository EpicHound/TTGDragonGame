using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("CurrentScore", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
